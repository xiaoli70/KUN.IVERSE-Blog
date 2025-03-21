export default {
    // ...
    server: {
      port: 3000,
      host: "0.0.0.0",
      hmr: false,
      proxy: {
        "/api": {
          target: "http://111.173.104.127:8081/",
          ws: true,
          changeOrigin: true,
          secure: false, //解决target使用https出错问题
        },
      },
    },
    // ...
  }