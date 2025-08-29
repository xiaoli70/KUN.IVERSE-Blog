<template>
  <!-- 播放器组件 -->
  <div id="player"></div>
  <v-footer app absolute>
    <div class="footer-wrap">
      <div>{{ blogSetting.copyright }}</div>
      <a href="https://beian.miit.gov.cn/" target="_blank">
        {{ blogSetting.filing }}
      </a>
    </div>
  </v-footer>
</template>

<script setup lang="ts">
import { onMounted } from "vue";
import { storeToRefs } from "pinia";
import "APlayer/dist/APlayer.min.css";
import APlayer from "APlayer";
import { useApp } from "@/stores/app";
const appStore = useApp();
const { blogSetting } = storeToRefs(appStore);
// onMounted(() => {
//   //播放器文档api https://aplayer.js.org/#/zh-Hans/
//   const op = new APlayer({
//     container: document.getElementById("player")!,
//     fixed: true,
//     autoplay: true,
//     audio: [
//       {
//         name: "海阔天空",
//         artist: "Beyond",
//         url: "http://192.168.18.13:5000/oss/music/songs/海阔天空.mp3",
//         cover: "",
//         lrc: "",
//       },
//     ],
//   });
// });
</script>

<style scoped>
#player {
  z-index: 9999;
}
footer {
  padding: 0;
}
.footer-wrap {
  width: 100%;
  line-height: 2;
  position: relative;
  padding: 40px 20px;
  color: #eee;
  font-size: 14px;
  text-align: center;
  background: linear-gradient(-45deg, #ee7752, #ce3e75, #23a6d5, #23d5ab);
  background-size: 400% 400%;
  animation: Gradient 10s ease infinite;
}
.footer-wrap a {
  color: #eee !important;
}
@keyframes Gradient {
  0% {
    background-position: 0 50%;
  }
  50% {
    background-position: 100% 50%;
  }
  100% {
    background-position: 0 50%;
  }
}
</style>
