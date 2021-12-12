<template>
  <div class="container mt-5">
    <table class="table">
      <thead>
        <tr>
          <th scope="col">Id</th>
          <th scope="col">Product Name</th>
          <th scope="col">Color Count</th>
          <th scope="col">Fabric Count</th>
          <th scope="col">Image Count</th>
          <th scope="col"></th>
        </tr>
      </thead>
      <tbody>
        <tr
          v-for="product in productList"
          :key="product.Id"
          v-bind:productList="productList"
        >
          <th scope="row">{{ product.productId }}</th>
          <td>{{ product.productName }}</td>
          <td>{{ product.colorCount }}</td>
          <td>{{ product.fabricCount }}</td>
          <td>{{ product.imageCount }}</td>
          <td>
            <router-link
              :to="{
                name: 'ProductDetail',
                params: { productId: product.productId },
              }"
              class="btn btn-primary"
              >Edit Images
            </router-link>
          </td>
        </tr>
      </tbody>
    </table>
  </div>
</template>

<script>
import axios from "axios";

export default {
  name: "ProductList",
  data() {
    return {
      productList: [],
    };
  },
  props: {
    msg: String,
  },
  mounted() {
    axios
      .get("http://localhost:62766/api/Product/GetProductList")
      .then((response) => {
        let data = response.data;
        console.log(response);
        if (data.success == true) {
          this.productList = data.response;
        }
        console.log(this.productList);
      });
  },
};
</script>

<style scoped></style>
