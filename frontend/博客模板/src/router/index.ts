import { createRouter, createWebHistory, RouteRecordRaw } from "vue-router";
import NProgress from "nprogress";
import "nprogress/nprogress.css";
import Index from "../views/Index.vue";

const routes: Array<RouteRecordRaw> = [
  {
    name: "home",
    path: "/",
    component: Index,
    meta: {
      title: "首页",
    },
  },
  {
    name: "articles",
    path: "/articles",
    component: () => import("../views/article/List.vue"),
    meta: {
      title: "博文列表",
    },
  },
  {
    name: "archives",
    path: "/archives",
    component: () => import("../views/article/Archives.vue"),
    meta: {
      title: "归档",
    },
  },
  {
    name: "category",
    path: "/category",
    component: () => import("../views/article/Category.vue"),
    meta: {
      title: "分类",
    },
  },
  {
    name: "categories",
    path: "/categories/:id",
    component: () => import("../views/article/CategoryList.vue"),
    meta: {
      title: "分类",
    },
  },
  {
    name: "tags",
    path: "/tags",
    component: () => import("../views/article/Tag.vue"),
    meta: {
      title: "标签",
    },
  },
  {
    name: "tagsList",
    path: "/tags/:id",
    component: () => import("../views/article/CategoryList.vue"),
    meta: {
      title: "分类",
    },
  },
  {
    name: "detail",
    path: "/articles/:id",
    component: () => import("../views/article/Detail.vue"),
    meta: {
      title: "详情",
    },
  },
  {
    name: "message",
    path: "/message",
    component: () => import("../views/Message.vue"),
    meta: {
      title: "留言板",
    },
  },
  {
    name: "talks",
    path: "/talks",
    component: () => import("../views/Talks.vue"),
    meta: {
      title: "说说",
    },
  },
  {
    name: "talkInfo",
    path: "/talks/:talkId",
    component: () => import("../views/Talk.vue"),
    meta: {
      title: "说说",
    },
  },
  {
    name: "albums",
    path: "/albums",
    component: () => import("../views/album/Album.vue"),
    meta: {
      title: "相册",
    },
  },
  {
    name: "photo",
    path: "/albums/:id",
    component: () => import("../views/album/Photo.vue"),
    meta: {
      title: "图片",
    },
  },
  {
    name: "links",
    path: "/links",
    component: () => import("../views/Link.vue"),
    meta: {
      title: "友情链接",
    },
  },
  {
    name: "about",
    path: "/about",
    component: () => import("../views/About.vue"),
    meta: {
      title: "关于",
    },
  },
  {
    name: "user",
    path: "/user",
    component: () => import("../views/User.vue"),
    meta: {
      title: "用户中心",
    },
  },{
    name: "love",
    path: "/love",
    component: () => import("../views/article/Love.vue"),
    meta: {
      title: "恋爱",
    },
  },
];

const router = createRouter({
  history: createWebHistory(),
  routes,
});

//路由器安置守卫
router.beforeEach((to, from, next) => {
  NProgress.start();
  if (to.meta.title) {
    document.title = to.meta.title as string;
  }
  next();
});

router.afterEach(() => {
  window.scrollTo({
    top: 0,
  });
  NProgress.done();
});

export default router;
