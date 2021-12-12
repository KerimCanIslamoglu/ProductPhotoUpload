<template>
  <div class="container mt-5">
    <div class="d-flex flex-row">
      <label class="ms-2"
        >Product Id:
        <span
          >{{ productDetailList.length > 0 && productDetailList[0].productId }}
        </span>
      </label>
      <label class="ps-5"
        >Product Name:
        <span>{{
          productDetailList.length > 0 && productDetailList[0].productName
        }}</span></label
      >
    </div>

    <table class="table table-borderless mt-5">
      <thead>
        <tr>
          <th scope="col"></th>
          <th scope="col" v-for="color in colorList" :key="color.colorId">
            {{ color.colorName }}
          </th>
        </tr>
      </thead>
      <tbody>
        <tr v-for="fabric in fabricList" :key="fabric.fabricId">
          <th style="height: 100px" scope="row">{{ fabric.fabricName }}</th>
          <td
            v-for="color in colorList"
            :key="color.colorId"
            class="image-list-td"
          >
            <div
              class="image"
              v-for="image in imageRender(fabric.fabricId, color.colorId)"
              :key="image.id"
            >
              <button
                type="button"
                class="close-button"
                @click="deleteImage(image.id)"
              >
                -
              </button>
              <img
                v-bind:src="'http://localhost:62766' + image.imageUrl"
                v-bind:alt="image.imageName"
                class="img img-responsive full-width"
              />
            </div>
            <input
              id="fileUpload"
              type="file"
              @change="onFileChange"
              hidden
              ref="file"
            />
            <button
              class="btn btn-primary btn-sm ms-2"
              @click="chooseFiles"
              v-bind:fabricId="fabric.fabricId"
              v-bind:colorId="color.colorId"
            >
              Add
            </button>
          </td>
        </tr>
      </tbody>
    </table>
  </div>
</template>

<script>
import axios from "axios";

export default {
  name: "ProductDetail",
  data() {
    return {
      productDetailList: [],
      colorList: [],
      fabricList: [],
      image: {},
      productId: 0,
      colorId: 0,
      fabricId: 0,
    };
  },
  mounted() {
    this.productId = this.$route.params.productId;
    this.getProductDetail(this.productId);
  },
  methods: {
    getProductDetail(productId) {
      axios
        .get("http://localhost:62766/api/Product/GetProductDetail/" + productId)
        .then((response) => {
          console.log(response);
          let data = response.data;
          console.log(data);
          if (data.success == true) {
            this.productDetailList = data.response;

            this.colorList = Array.from(
              new Set(data.response.map((x) => x.colorId))
            ).map((id) => {
              return {
                colorId: id,
                colorName: data.response.find((x) => x.colorId == id).colorName,
              };
            });

            this.fabricList = Array.from(
              new Set(data.response.map((x) => x.fabricId))
            ).map((id) => {
              return {
                fabricId: id,
                fabricName: data.response.find((x) => x.fabricId == id)
                  .fabricName,
              };
            });

            console.log(this.colorList);
            console.log(this.fabricList);
          }
        });
    },
    imageRender(fabricId, colorId) {
      return this.productDetailList.filter((product) => {
        return product.colorId == colorId && product.fabricId == fabricId;
      });
    },
    deleteImage(id) {
      console.log(id);
      console.log("Hello");

      axios
        .delete("http://localhost:62766/api/Product/DeleteProductDetail/" + id)
        .then((res) => {
          console.log(res);
          this.getProductDetail(this.productId);
        })
        .catch((ex) => {
          console.log(ex);
        });
    },
    chooseFiles(e) {
      document.getElementById("fileUpload").click();
      this.colorId = e.currentTarget.getAttribute("colorId");
      this.fabricId = e.currentTarget.getAttribute("fabricId");
    },
    submitFile(file) {
      const formData = new FormData();
      formData.append("formFile", file);
      formData.append("colorId", this.colorId);
      formData.append("fabricId", this.fabricId);
      formData.append("productId", this.productId);
      const headers = { "Content-Type": "multipart/form-data" };
      axios
        .post(
          "http://localhost:62766/api/Product/UploadProductImage",
          formData,
          { headers }
        )
        .then((res) => {
          console.log(res);
          this.getProductDetail(this.productId);
          document.getElementById("fileUpload").value = "";
        })
        .catch((ex) => {
          console.log(ex);
        });
    },
    onFileChange(e) {
      var files = e.currentTarget.files || e.dataTransfer.files;
      if (!files.length) return;
      this.submitFile(files[0]);
    },
  },
};
</script>

<style scoped>
.img-responsive {
  height: 80px;
  width: 50px;
  margin: 10px;
}
.image {
  position: relative;
  display: inline-block;
}
.image-list-td {
}
.close-button {
  right: 0px;
  position: absolute;
  border: none;
  border: solid 1px red;
  border-radius: 25px;
  background: rgba(255, 255, 255, 0);
  color: black;
}

.close-button:hover {
  background: red;
  color: white;
}
</style>
