import { createRouter, createWebHistory } from "vue-router";

import OnboardingLayout from "../views/onboarding/layout/OnboardingLayout.vue";
import PersonalDetails from "../views/onboarding/PersonalDetails.vue";
import BankDetails from "../views/onboarding/BankDetails.vue";
import Superannuation from "../views/onboarding/Superannuation.vue";
import Password from "../views/onboarding/Password.vue";
import NotFound from "../views/404.vue";

const routes = [
  {
    path: "/onboarding/:token/",
    component: OnboardingLayout,
    children: [
      {
        name: "personal",
        path: "personal-details",
        component: PersonalDetails,
      },
      {
        name: "bank",
        path: "bank-details",
        component: BankDetails,
      },
      {
        name: "super",
        path: "superannuation",
        component: Superannuation,
      },
    ],
  },
  {
    name: "password",
    path: "/onboarding/:token/password",
    component: Password,
  },
  {
    path: "/:pathMatch(.*)*",
    component: NotFound,
  },
];

const router = createRouter({
  history: createWebHistory(),
  routes,
});

export default router;
