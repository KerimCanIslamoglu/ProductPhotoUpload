import { createWebHistory, createRouter } from "vue-router";
import ProductList from '../views/ProductList.vue'
import ProductDetail from '../views/ProductDetail.vue'


const routes = [
    {
        path: "/",
        name: "Home",
        component: ProductList,
    },
    {
        path: "/product-list",
        name: "ProductList",
        component: ProductList,
    },
    {
        path: "/product-detail/:productId",
        name: "ProductDetail",
        component: ProductDetail,
    },
    {
        path: "/:catchAll(.*)",
        component: ProductList,
    }
];


const router = createRouter({
    history: createWebHistory(),
    routes,
});

export default router;