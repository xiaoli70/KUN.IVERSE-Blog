<template>
  <div class="rightside" :style="isShow">
    <div :class="'rightside-config-hide ' + isOut">
      <i :class="'iconfont rightside-icon ' + icon" @click="check" />
      <img src="../assets/icons/music.svg" class="rightside-icon" @click="togglePlay" />
    </div>
    <div class="setting-container" @click="show">
      <i class="iconfont iconshezhi setting" />
    </div>
    <i @click="backTop" class="iconfont rightside-icon iconziyuanldpi" />
  </div>
</template>

<script setup lang="ts">
import { ref, Ref, onMounted, onUnmounted } from "vue";
import { useThemeSettingStore } from "../stores/themeSetting";
const scrollTop: Ref<number> = ref(0);
const isShow: Ref<string> = ref("");
const isOut: Ref<string> = ref("rightside-out");
const icon: Ref<string> = ref("iconyueliang");
const isPlaying: Ref<boolean> = ref(false);
const audio: Ref<HTMLAudioElement | null> = ref(null);

// 返回顶部
const backTop = (): void => {
  window.scrollTo({
    top: 0,
    behavior: "smooth",
  });
};
// 为了计算距离顶部的高度，当高度大于100显示回顶部图标，小于100则隐藏
const scrollToTop = (): void => {
  let st: number =
    window.pageYOffset ||
    document.documentElement.scrollTop ||
    document.body.scrollTop;
  scrollTop.value = st;
  isShow.value =
    scrollTop.value > 20 ? "opacity: 1;transform: translateX(-38px);" : "";
};
const show = (): void => {
  isOut.value =
    isOut.value === "rightside-out" ? "rightside-in" : "rightside-out";
};

const check = (): void => {

  icon.value = icon.value === "iconyueliang" ? "icontaiyang" : "iconyueliang";
  const store = useThemeSettingStore();
  store.setTheme(store.theme === "dark" ? "light" : "dark");
};
onMounted(() => {
  window.addEventListener("scroll", scrollToTop);
});
const togglePlay = (): void => {
  if (!audio.value) {
    audio.value = new Audio('http://111.173.104.127:8081/oss/music/songs/海阔天空.mp3');
  }
  
  if (isPlaying.value) {
    audio.value.pause();
  } else {
    audio.value.play();
  }
  isPlaying.value = !isPlaying.value;
};

onUnmounted(() => {
  window.removeEventListener("scroll", scrollToTop);
  if (audio.value) {
    audio.value.pause();
    audio.value = null;
  }
});
</script>

<style scoped>
.rightside {
  z-index: 4;
  position: fixed;
  right: -38px;
  bottom: 85px;
  transition: all 0.5s;
  z-index: 1005;
}
.rightside-config-hide {
  transform: translate(35px, 0);
}
.rightside-out {
  animation: rightsideOut 0.3s;
}
.rightside-in {
  transform: translate(0, 0) !important;
  animation: rightsideIn 0.3s;
}
.rightside-icon,
.setting-container {
  display: block;
  margin-bottom: 2px;
  width: 30px;
  height: 30px;
  background-color: #49b1f5;
  color: #fff;
  text-align: center;
  font-size: 16px;
  line-height: 30px;
  cursor: pointer;
}

.rightside-icon:hover,
.setting-container:hover {
  background-color: #ff7242;
}
.setting-container i {
  display: block;
  animation: turn-around 2s linear infinite;
}
@keyframes turn-around {
  0% {
    transform: rotate(0);
  }
  100% {
    transform: rotate(360deg);
  }
}
@keyframes rightsideOut {
  0% {
    transform: translate(0, 0);
  }
  100% {
    transform: translate(30px, 0);
  }
}
@keyframes rightsideIn {
  0% {
    transform: translate(30px, 0);
  }
  100% {
    transform: translate(0, 0);
  }
}
</style>
