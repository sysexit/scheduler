import { createApp } from "vue";
import axios from "axios";

import App from "./App.vue";
import router from "./router";
import store from "./store";
import "./styles/index.scss";

window.axios = axios;
axios.defaults.baseURL = "http://hr.domain.com/api"; // Change to HTTPs as needed

createApp(App).use(store).use(router).mount("#app");
