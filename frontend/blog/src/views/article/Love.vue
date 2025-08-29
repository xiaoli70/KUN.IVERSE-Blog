<template>
  
  <!-- banner -->
  <div class="banner2" :style="cover">
    <!-- 动态粒子背景 -->
    <!-- <div class="particles-container">
      <div class="particle" v-for="i in 50" :key="i" :style="{
        left: Math.random() * 100 + '%',
        top: Math.random() * 100 + '%',
        animationDelay: Math.random() * 20 + 's',
        animationDuration: (Math.random() * 10 + 15) + 's'
      }"></div>
    </div> -->

    <!-- 添加浮动的爱心 -->
    <div class="floating-hearts">
      <div class="heart" v-for="i in 20" :key="i" :style="{
        left: Math.random() * 100 + '%',
        animationDelay: Math.random() * 5 + 's',
        animationDuration: (Math.random() * 4 + 3) + 's'
      }">💖</div>
    </div>

    <!-- 光晕效果 -->
    <div class="light-orbs">
      <div class="orb orb-1"></div>
      <div class="orb orb-2"></div>
      <div class="orb orb-3"></div>
    </div>

    <!-- 简化的banner装饰 -->
    <div class="banner-decoration">
      <div class="decoration-text">Love Story</div>
    </div>
  </div>
  <!-- 对象-->
  <div class="love-wrap">
    <!-- 背景装饰 -->
    <div class="love-bg-decoration">
      <div class="bg-circle bg-circle-1"></div>
      <div class="bg-circle bg-circle-2"></div>
      <div class="bg-circle bg-circle-3"></div>
    </div>

    <!-- 内容包装器 -->
    <div class="love-content-wrapper">

    <!-- 左侧人物 -->
    <div class="love-person" data-aos="fade-right">
      <div class="avatar-container">
        <div class="avatar-frame">
          <v-avatar size="140" class="love-avatar" :image="love.manCover" />
          <div class="avatar-ring"></div>
          <div class="avatar-glow"></div>
          <div class="avatar-sparkles">
            <span class="sparkle sparkle-1">✨</span>
            <span class="sparkle sparkle-2">⭐</span>
            <span class="sparkle sparkle-3">💫</span>
          </div>
        </div>
      </div>
      <div class="person-info">
        <div class="love-title">
          {{ love.manName }}
        </div>
        <div class="love-role">💙 男主角</div>
        <div class="person-quote">"遇见你是我最美的意外"</div>
      </div>
    </div>

    <!-- 中间时间内容 -->
    <div class="love-center" data-aos="zoom-in" data-aos-delay="200">
      <div class="center-heart">
        <div class="heart-icon">💖</div>
        <div class="heart-text">Forever</div>
      </div>
<h1 class="love-main-title-standalone">
            <span class="title-word" style="animation-delay: 0.1s">Our</span>
            <span class="title-word" style="animation-delay: 0.3s">Love</span>
            <span class="title-word" style="animation-delay: 0.5s">Story</span>
          </h1>
      <div class="love-connection">
        
        <div class="connection-line"></div>
        
        <div class="connection-hearts">
          <span class="mini-heart">💕</span>
          <!-- <span class="mini-heart">💖</span> -->
          <span class="mini-heart">💕</span>
        </div>
      </div>
    </div>

    <!-- 右侧人物 -->
    <div class="love-person" data-aos="fade-left" data-aos-delay="100">
      <div class="avatar-container">
        <div class="avatar-frame">
          <v-avatar size="140" class="love-avatar" :image="love.womanCover" />
          <div class="avatar-ring"></div>
          <div class="avatar-glow"></div>
          <div class="avatar-sparkles">
            <span class="sparkle sparkle-1">✨</span>
            <span class="sparkle sparkle-2">⭐</span>
            <span class="sparkle sparkle-3">💫</span>
          </div>
        </div>
      </div>
      <div class="person-info">
        <div class="love-title">
          {{ love.womanName }}
        </div>
        <div class="love-role">💖 女主角</div>
        <div class="person-quote">"和你在一起就是最好的时光"</div>
      </div>
    </div>

    </div> <!-- 结束 love-content-wrapper -->
  </div>

  <div id="bannerWave1"></div>
  <div id="bannerWave2"></div>

  <div class="love-container ">
    <!-- 时间显示区域 -->
    <div class="time-section-standalone">
      <div class="time-container-standalone">
        <!-- 主标题 -->
        <div class="time-main-title">
          
          <div class="title-decoration-standalone">
            <span class="decoration-line"></span>
            <span class="decoration-heart">💕</span>
            <span class="decoration-line"></span>
          </div>
          <p class="love-subtitle-standalone">时光不老，我们不散</p>
        </div>

        <!-- 时间显示 -->
        <div class="time-display-standalone">
          <div class="love-time-title-standalone">
            <span class="title-icon">💕</span>
            这是我们一起走过的
            <span class="title-icon">💕</span>
          </div>
          <div class="love-time-standalone">
            <div class="time-block-standalone">
              <span class="love-time-item-standalone">{{ timing.year }}</span>
              <span class="time-unit-standalone">年</span>
            </div>
            <div class="time-block-standalone">
              <span class="love-time-item-standalone">{{ timing.month }}</span>
              <span class="time-unit-standalone">月</span>
            </div>
            <div class="time-block-standalone">
              <span class="love-time-item-standalone">{{ timing.day }}</span>
              <span class="time-unit-standalone">日</span>
            </div>
            <div class="time-block-standalone">
              <span class="love-time-item-standalone">{{ timing.hour }}</span>
              <span class="time-unit-standalone">时</span>
            </div>
            <div class="time-block-standalone">
              <span class="love-time-item-standalone">{{ timing.minute }}</span>
              <span class="time-unit-standalone">分</span>
            </div>
            <div class="time-block-standalone">
              <span class="love-time-item-standalone">{{ timing.second }}</span>
              <span class="time-unit-standalone">秒</span>
            </div>
          </div>
          <div class="time-message-standalone">
            <p>💖 每一秒都是爱你的证明 💖</p>
          </div>
        </div>
      </div>
    </div>
    <div class="myCenter love-content">
      <div style="padding: 40px 20px 0" class="padfix">
      <!-- 卡片 -->
      <div class="card-wrap" v-show="card !== 4">
        <div class="card-content love-card" @click="changeCard(1)" :class="{ active: card === 1 }">
          <div class="card-icon-container">
            <div class="card-icon timeline-icon">
              <span class="icon-emoji">📖</span>
            </div>
            <div class="card-glow"></div>
          </div>
          <div class="card-right">
            <div class="card-title">
              <span class="title-gradient">点点滴滴</span>
            </div>
            <div class="card-desc">
              💫 记录我们的美好时光
            </div>
          </div>
          <div class="card-arrow">→</div>
        </div>

        <div class="card-content love-card" @click="changeCard(2)" :class="{ active: card === 2 }">
          <div class="card-icon-container">
            <div class="card-icon photo-icon">
              <span class="icon-emoji">📷</span>
            </div>
            <div class="card-glow"></div>
          </div>
          <div class="card-right">
            <div class="card-title">
              <span class="title-gradient">时光相册</span>
            </div>
            <div class="card-desc">
              🌸 定格每个甜蜜瞬间
            </div>
          </div>
          <div class="card-arrow">→</div>
        </div>

        <div class="card-content love-card" @click="changeCard(3)" :class="{ active: card === 3 }">
          <div class="card-icon-container">
            <div class="card-icon blessing-icon">
              <span class="icon-emoji">💌</span>
            </div>
            <div class="card-glow"></div>
          </div>
          <div class="card-right">
            <div class="card-title">
              <span class="title-gradient">祝福板</span>
            </div>
            <div class="card-desc">
              🎈 收集大家的美好祝愿
            </div>
          </div>
          <div class="card-arrow">→</div>
        </div>
      </div>

      <div class="card-container">
        <div v-show="card === 1" class="timeline-container">
          <div class="timeline-header">
            <h2 class="timeline-main-title">
              <span class="title-icon">💕</span>
              我们的爱情故事
              <span class="title-icon">💕</span>
            </h2>
            <p class="timeline-subtitle">每一个重要的时刻，都值得被记住</p>
          </div>

          <div class="custom-timeline">
            <div class="timeline-item" v-for="(item, index) in timelineData" :key="index">
              <div class="timeline-dot">
                <span class="dot-icon">{{ item.icon }}</span>
              </div>
              <div class="timeline-content">
                <div class="timeline-date">{{ item.date }}</div>
                <div class="timeline-title">{{ item.title }}</div>
                <div class="timeline-desc">{{ item.desc }}</div>
              </div>
            </div>
          </div>
        </div>
        <div v-show="card === 2" class="photo-container">
          <div class="masonry-grid">
            <div v-for="(photo, index) in photos" :key="index" class="masonry-item">
              <div class="photo-card" @click="openPhotoPreview(index)">
                <v-img
                  :src="photo.src"
                  :alt="photo.alt"
                  cover
                  :aspect-ratio="photo.aspectRatio || 1"
                  class="photo-image"
                >
                  <template v-slot:placeholder>
                    <div class="photo-loading">
                      <v-progress-circular indeterminate color="primary"></v-progress-circular>
                    </div>
                  </template>
                </v-img>
                <div class="photo-overlay">
                  <span class="photo-title">{{ photo.alt }}</span>
                </div>
              </div>
            </div>
          </div>
          <v-row>
      <v-col>
        <v-pagination
          v-if="state.pages > 1"
          v-model="state.query.pageNo"
          size="x-small"
          :length="state.pages"
          active-color="#00C4B6"
          :total-visible="3"
          variant="elevated"
        ></v-pagination>
      </v-col>
    </v-row>
          <!-- 图片预览对话框 -->
          <v-dialog v-model="showPreview" fullscreen>
            <div class="preview-container" @click.self="closePreview">
              <v-btn icon="mdi-close" class="preview-close" @click="closePreview"></v-btn>
              <v-btn icon="mdi-chevron-left" class="preview-nav preview-prev" @click="prevPhoto" :disabled="currentPhotoIndex === 0"></v-btn>
              <v-btn icon="mdi-chevron-right" class="preview-nav preview-next" @click="nextPhoto" :disabled="currentPhotoIndex === photos.length - 1"></v-btn>
              
              <div class="preview-content">
                <v-img
                  :src="currentPhoto?.src"
                  :alt="currentPhoto?.alt"
                  class="preview-image"
                  contain
                  :width="previewDimensions.width"
                  :height="previewDimensions.height"
                >
                  <template v-slot:placeholder>
                    <div class="preview-loading">
                      <v-progress-circular indeterminate color="primary" size="64"></v-progress-circular>
                    </div>
                  </template>
                </v-img>
                <div class="preview-caption">{{ currentPhoto?.alt }}</div>
              </div>
            </div>
          </v-dialog>
        </div>
        <div v-show="card === 3" class="blessing-container">
          <div class="blessing-header">
            <h2 class="blessing-main-title">
              <span class="title-icon">💌</span>
              爱的祝福墙
              <span class="title-icon">💌</span>
            </h2>
            <p class="blessing-subtitle">留下你们对我们的美好祝愿吧</p>
          </div>

          <div class="blessing-form">
            <div class="form-container">
              <v-textarea
                v-model="newBlessing"
                label="✨ 写下你的祝福"
                placeholder="愿你们的爱情如诗如画，永远甜蜜..."
                variant="outlined"
                rows="3"
                clearable
                class="blessing-input"
                color="pink"
              ></v-textarea>
              <v-btn
                color="pink"
                class="heart-button"
                @click="addBlessing"
                :disabled="!newBlessing.trim()"
                size="large"
              >
                <v-icon left>mdi-heart</v-icon>
                发送祝福
              </v-btn>
            </div>
          </div>

          <div class="blessing-wall">
            <div class="blessing-stats">
              <span class="stats-text">
                <v-icon color="pink">mdi-heart-multiple</v-icon>
                已收到 {{ state1.commentList.length }} 份祝福
              </span>
            </div>

            <div class="blessing-list">
              <div
                v-for="(blessing, index) in state1.commentList"
                :key="index"
                class="blessing-card"
                :style="{ animationDelay: index * 0.1 + 's' }"
              >
                <div class="blessing-header-card">
                  <div class="blessing-avatar">
                    <v-icon color="pink">mdi-account-heart</v-icon>
                  </div>
                  <div class="blessing-info">
                    <div class="blessing-author">匿名祝福者</div>
                    <div class="blessing-date">{{ blessing.createdTime }}</div>
                  </div>
                  <div class="blessing-heart">💖</div>
                </div>
                <div class="blessing-content">
                  "{{ blessing.content }}"
                </div>
                <div class="blessing-decoration">
                  <span class="decoration-heart">💕</span>
                  <span class="decoration-heart">💖</span>
                  <span class="decoration-heart">💕</span>
                </div>
              </div>
            </div>

            <div v-if="state1.commentList.length === 0" class="empty-blessing">
              <div class="empty-icon">💌</div>
              <p>还没有收到祝福呢，快来留下第一份祝福吧！</p>
            </div>
          </div>
        </div>
      </div>

      </div>
    </div>

  </div>
</template>

<script setup lang="ts">
import { ref, reactive, computed, onMounted, watch } from "vue";
import AlbumsApi from "@/api/AlbumsApi";
import men from "../../assets/images/man.jpg";
import women from "../../assets/images/women.jpg";
import { useApp } from "@/stores/app";
import { getFullImageUrl } from "@/utils/config";
import CommentApi from "@/api/CommentApi";
import type { PictureOutput } from "@/api/models";
import type { Pagination } from "@/api/models/pagination";
import type { CommentOutput } from "@/api/models";

const appStore = useApp();
// 添加移动设备检测
const isMobile = computed(() => {
  return window.innerWidth <= 768;
});
const state = reactive({
  photos: [] as PictureOutput[],
  cover: "",
  name: "",
  pages: 0,
  query: {
    pageNo: 1,
    pageSize: 5,
    albumId: 285286305832965 as never,
  } as Pagination,
});
watch(
  () => state.query.pageNo,
  async () => {
    window.scrollTo(0, 250);
    await loadData();
  }
);

const loadData = async () => {
  const { data, extras } = await AlbumsApi.pictures(state.query);
  console.log(extras)
  if (extras) {
    state.photos = data?.rows ?? [];
    state.pages = data?.pages ?? 0;
    photos.value = [
    ...state.photos.map((item: PictureOutput) => ({
      src: getFullImageUrl(item.url || ''),
      alt: '我们的照片',
      aspectRatio: 1
    }))
  ];
  }
};
let current = ref(1);
const cover = ref(
  "background: url(" +
    getFullImageUrl(appStore.loveCover()) +
    ") center center / cover no-repeat"
);
const love = reactive({
  manName: "KUN",
  womanCover: women,
  womanName: "YING",
  manCover: men,
  path: "E:\\VSWork\\MyGitHub\\个人博客网站Blog\\可乐不加冰Easy.Admin\\src\\frontend\\博客模板\\Sara11704792567121932.svg"
});

// 时间线数据
const timelineData = ref([
  {
    date: "2020-09-13",
    title: "初次相遇",
    desc: "那一天，我们在最美的时光里相遇了",
    icon: "💫"
  },
  {
    date: "2020-12-25",
    title: "第一次约会",
    desc: "圣诞节的雪花见证了我们的第一次约会",
    icon: "🎄"
  },
  {
    date: "2021-02-14",
    title: "第一个情人节",
    desc: "玫瑰花和巧克力，还有你甜甜的笑容",
    icon: "🌹"
  },
  {
    date: "2021-09-13",
    title: "相恋一周年",
    desc: "365天的陪伴，每一天都是甜蜜的回忆",
    icon: "💝"
  },
  {
    date: "2022-09-13",
    title: "相恋两周年",
    desc: "两年的时光，我们一起成长，一起变得更好",
    icon: "🎂"
  },
  {
    date: "2023-09-13",
    title: "相恋三周年",
    desc: "三年的爱情长跑，我们依然热恋如初",
    icon: "💖"
  }
]);
const card = ref<number>(0);
const timing = reactive({
  year: 0,
  month: 0,
  day: 0,
  hour: 0,
  minute: 0,
  second: 0
});

type ImageModule = {
  default: string;
};



const photos = ref([
  // 添加从API获取的图片
  ...(state?.photos || []).map((item: PictureOutput) => ({
    src: item.url,
    alt: '我们的照片',
    aspectRatio: 1
  }))
]);

// 图片预览相关状态
const showPreview = ref(false);
const currentPhotoIndex = ref(0);
const previewDimensions = reactive({
  width: 0,
  height: 0
});

// 计算当前预览的图片
const currentPhoto = computed(() => photos.value[currentPhotoIndex.value]);

// 打开图片预览
const openPhotoPreview = (index: number) => {
  currentPhotoIndex.value = index;
  showPreview.value = true;
  updatePreviewDimensions();
};

// 关闭预览
const closePreview = () => {
  showPreview.value = false;
};

// 上一张图片
const prevPhoto = () => {
  if (currentPhotoIndex.value > 0) {
    currentPhotoIndex.value--;
  }
};

// 下一张图片
const nextPhoto = () => {
  if (currentPhotoIndex.value < photos.value.length - 1) {
    currentPhotoIndex.value++;
  }
};

// 更新预览图片尺寸
const updatePreviewDimensions = () => {
  const windowWidth = window.innerWidth * (isMobile.value ? 0.95 : 0.9);
  const windowHeight = window.innerHeight * (isMobile.value ? 0.9 : 0.8);
  
  previewDimensions.width = windowWidth;
  previewDimensions.height = windowHeight;
};
// 监听窗口大小变化
onMounted(() => {
  window.addEventListener('resize', updatePreviewDimensions);
});
const newBlessing = ref('');
const blessings = ref([
  { content: '烟花短暂，我们永恒', date: '2025-1-08' },
  { content: '何其有幸，岁岁并进', date: '2024-11-07' },
]);
const state1 = reactive({
  reFresh: true,
  commentContent: "",
  chooseEmoji: false,
  current: 1,
  commentList: [] as Array<CommentOutput>,
  count: 0,
  pages: 0,
});
const openPhoto = (photo: { src: string; alt: string }) => {
  // 实现查看大图功能
  console.log('查看图片:', photo);
};

const addBlessing = async () => {
  if (newBlessing.value.trim()) {
    const { succeeded } = await CommentApi.addbless({
        moduleId: 1,
      content: newBlessing.value,
    });
    if (succeeded) {
      loadBlessing();
      
    }
    newBlessing.value = '';
};}

const loadBlessing = async () => {
  const { data, succeeded } = await CommentApi.list({
    id: 1,
    pageNo: 1,
    pageSize: 1000,
  });
  if (state1.current === 1) {
    state1.commentList = data?.rows ?? [];
  } else {
    state1.commentList.push(...(data?.rows ?? []));
  }
};

const changeCard = async (index: number) => {
  if (index ===3){
    loadBlessing();
  }else if(index===2){
    await loadData();
  }
  
  card.value = index;
};
const startDate = ref('2020-09-13');
const currentTime = ref(new Date().toString());
const timeDiffComputed = computed(() => {
  return timeDiff(startDate.value, currentTime.value);
});

const getLove = () => {
  const diff = timeDiffComputed.value;
  timing.year = diff.diffYear;
  timing.month = diff.diffMonth;
  timing.day = diff.diffDay;
  timing.hour = diff.diffHour;
  const oldSecond = timing.second;
  timing.minute = diff.diffMinute;
  timing.second = diff.diffSecond;


 
};

const timeDiff = (oldTime: string | Date, newTime?: string | Date): {
  diffYear: number,
  diffMonth: number,
  diffDay: number,
  diffHour: number,
  diffMinute: number,
  diffSecond: number
} => {
  oldTime = (typeof oldTime === 'string') ? oldTime.replace(new RegExp("-", "gm"), "/") : oldTime.toString();
  if (newTime) {
    newTime = (typeof newTime === 'string') ? newTime.replace(new RegExp("-", "gm"), "/") : newTime.toString();
  } else {
    newTime = new Date().toString();
  }

  // 计算比较日期
  const getMaxMinDate = (time: string, twoTime: string, type: string): {
    minTime: string,
    maxTime: string,
    maxMinTong: string
  } => {
    let minTime = new Date(time).getTime() - new Date(twoTime).getTime() > 0 ? twoTime : time;
    let maxTime = new Date(time).getTime() - new Date(twoTime).getTime() > 0 ? time : twoTime;
    let maxDateDay = new Date(new Date(maxTime).getFullYear(), new Date(maxTime).getMonth() + 1, 0).getDate();
    let maxMinDate = new Date(minTime).getDate() > maxDateDay ? maxDateDay : new Date(minTime).getDate();
    let maxMinTong;
    if (type === 'month') {
      maxMinTong = new Date(maxTime).getFullYear() + '/' + (new Date(minTime).getMonth() + 1) + '/' + maxMinDate + ' ' + new Date(minTime).toLocaleTimeString('chinese', { hour12: false });
    } else {
      maxMinTong = new Date(maxTime).getFullYear() + '/' + (new Date(maxTime).getMonth() + 1) + '/' + maxMinDate + ' ' + new Date(minTime).toLocaleTimeString('chinese', { hour12: false });
    }
    return {
      minTime,
      maxTime,
      maxMinTong
    };
  };

  // 相差年份
  const getYear = (time: string, twoTime: string): number => {
    let oneYear = new Date(time).getFullYear();
    let twoYear = new Date(twoTime).getFullYear();
    const { minTime, maxTime, maxMinTong } = getMaxMinDate(time, twoTime, 'month');
    let chaYear = Math.abs(oneYear - twoYear);
    if (new Date(maxMinTong).getTime() > new Date(maxTime).getTime()) {
      chaYear--;
    }
    return chaYear;
  };

  // 相差月份
  const getMonth = (time: string, twoTime: string, value: number | undefined): number => {
    let oneMonth = new Date(time).getFullYear() * 12 + (new Date(time).getMonth() + 1);
    let twoMonth = new Date(twoTime).getFullYear() * 12 + (new Date(twoTime).getMonth() + 1);
    const { minTime, maxTime, maxMinTong } = getMaxMinDate(time, twoTime, 'day');
    let chaMonth = Math.abs(oneMonth - twoMonth);
    if (new Date(maxMinTong).getTime() > new Date(maxTime).getTime()) {
      chaMonth--;
    }
    if (value) {
      return chaMonth - value;
    } else {
      return chaMonth;
    }
  };

  // 相差天数
  const getDay = (time: string, twoTime: string, value: number | undefined): number => {
    let chaTime = Math.abs(new Date(time).getTime() - new Date(twoTime).getTime());
    if (value) {
      return parseInt((chaTime / 86400000).toString()) - value;
    } else {
      return parseInt((chaTime / 86400000).toString());
    }
  };

  // 相差小时
  const getHour = (time: string, twoTime: string, value: number | undefined): number => {
    let chaTime = Math.abs(new Date(time).getTime() - new Date(twoTime).getTime());
    if (value) {
      return parseInt((chaTime / 3600000).toString()) - value;
    } else {
      return parseInt((chaTime / 3600000).toString());
    }
  };

  // 相差分钟
  const getMinute = (time: string, twoTime: string, value: number | undefined): number => {
    let chaTime = Math.abs(new Date(time).getTime() - new Date(twoTime).getTime());
    if (value) {
      return parseInt((chaTime / 60000).toString()) - value;
    } else {
      return parseInt((chaTime / 60000).toString());
    }
  };

  // 相差秒
  const getSecond = (time: string, twoTime: string, value: number | undefined): number => {
    let chaTime = Math.abs(new Date(time).getTime() - new Date(twoTime).getTime());
    if (value) {
      return parseInt((chaTime / 1000).toString()) - value;
    } else {
      return parseInt((chaTime / 1000).toString());
    }
  };

  // 相差年月日时分秒
  const getDiffYMDHMS = (time: string, twoTime: string): {
    diffYear: number,
    diffMonth: number,
    diffDay: number,
    diffHour: number,
    diffMinute: number,
    diffSecond: number
  } => {
    const { minTime, maxTime, maxMinTong } = getMaxMinDate(time, twoTime, 'day');
    let diffDay1 = getDay(minTime, maxMinTong, undefined);
    if (new Date(maxMinTong).getTime() > new Date(maxTime).getTime()) {
      let prevMonth = new Date(maxMinTong).getMonth() - 1;
      let lastTime = new Date(maxMinTong).setMonth(prevMonth);
      diffDay1 = diffDay1 - getDay((new Date(lastTime).getFullYear() + '/' + (new Date(lastTime).getMonth() + 1) + '/' + new Date(lastTime).getDate()).toString(), maxMinTong, undefined);
    }
    let diffYear = getYear(time, twoTime);
    let diffMonth = getMonth(time, twoTime, diffYear * 12);
    let diffDay = getDay(time, twoTime, diffDay1);
    let diffHour = getHour(time, twoTime, getDay(time, twoTime, undefined) * 24);
    let diffMinute = getMinute(time, twoTime, (getDay(time, twoTime, undefined) * 24 * 60 + diffHour * 60));
    let diffSecond = getSecond(time, twoTime, (getDay(time, twoTime, undefined) * 24 * 60 * 60 + diffHour * 60 * 60 + diffMinute * 60));
    return {
      diffYear,
      diffMonth,
      diffDay,
      diffHour,
      diffMinute,
      diffSecond
    };
  };

  return getDiffYMDHMS(oldTime, newTime);
};
setInterval(() => {
  currentTime.value = new Date().toString();
  getLove();
}, 1000);

// 页面加载动画
onMounted(() => {
  // 添加页面入场动画类
  document.body.classList.add('love-page-loaded');

  // 延迟显示各个元素
  setTimeout(() => {
    const elements = document.querySelectorAll('.love-wrap, .time-section, .card-wrap');
    elements.forEach((el, index) => {
      setTimeout(() => {
        el.classList.add('animate-in');
      }, index * 200);
    });
  }, 500);
});
</script>

<style scoped>
.time {
  font-size: 0.75rem;
  color: #555;
  margin-right: 1rem;
}

/* 放大 */
@keyframes imgScale {
  0% {
    transform: scale(0.8, 0.8);
  }

  70% {
    transform: scale(1.3, 1.3);
  }

  100% {
    transform: scale(0.8, 0.8);
  }
}

@keyframes jianBian {

  0% {
    background-position: left top;
  }

  100% {
    background-position: right top;
  }
}

@keyframes gradientBG {
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

@font-face {
  font-family: SmileySans;
  src: url(../../assets/fonts/SmileySans.otf);
  font-display: swap;
}

.love-container {
  background:
    linear-gradient(135deg, rgba(102, 126, 234, 0.03) 0%, rgba(240, 147, 251, 0.03) 100%),
    radial-gradient(circle at 25% 25%, rgba(255, 154, 158, 0.05) 0%, transparent 50%),
    radial-gradient(circle at 75% 75%, rgba(102, 126, 234, 0.05) 0%, transparent 50%),
    linear-gradient(to right, rgba(37, 82, 110, 0.08) 1px, transparent 1px),
    linear-gradient(to bottom, rgba(37, 82, 110, 0.08) 1px, transparent 1px);
  background-size: 100% 100%, 800px 800px, 600px 600px, 4rem 4rem, 4rem 4rem;
  background-attachment: fixed, fixed, fixed, local, local;
  position: relative;
  margin-top: -60px;
  padding-top: 0px;
  overflow: hidden;
}

.love-container::before {
  content: '';
  position: absolute;
  top: 0;
  left: 0;
  right: 0;
  bottom: 0;
  background:
    radial-gradient(circle at 20% 20%, rgba(255, 154, 158, 0.02) 0%, transparent 40%),
    radial-gradient(circle at 80% 80%, rgba(102, 126, 234, 0.02) 0%, transparent 40%);
  animation: backgroundFloat 30s ease-in-out infinite;
  pointer-events: none;
}

@keyframes backgroundFloat {
  0%, 100% {
    transform: translateX(0) translateY(0);
  }
  25% {
    transform: translateX(20px) translateY(-10px);
  }
  50% {
    transform: translateX(-10px) translateY(20px);
  }
  75% {
    transform: translateX(-20px) translateY(-15px);
  }
}

.banner2 {
  position: absolute;
  background: linear-gradient(135deg, #667eea 0%, #764ba2 50%, #f093fb 100%);
  top: -60px;
  left: 0;
  right: 0;
  height: 500px;
  animation: header-effect 1s;
  overflow: hidden;
  position: relative;
}

.banner2::before {
  content: '';
  position: absolute;
  top: 0;
  left: 0;
  right: 0;
  bottom: 0;
  background:
    radial-gradient(circle at 20% 80%, rgba(255, 255, 255, 0.1) 0%, transparent 50%),
    radial-gradient(circle at 80% 20%, rgba(255, 255, 255, 0.1) 0%, transparent 50%),
    radial-gradient(circle at 40% 40%, rgba(255, 255, 255, 0.05) 0%, transparent 50%);
  animation: backgroundShift 20s ease-in-out infinite;
}

@keyframes backgroundShift {
  0%, 100% { opacity: 1; }
  50% { opacity: 0.7; }
}

/* 动态粒子背景 */
.particles-container {
  position: absolute;
  width: 100%;
  height: 100%;
  pointer-events: none;
  overflow: hidden;
}

.particle {
  position: absolute;
  width: 4px;
  height: 4px;
  background: rgba(255, 255, 255, 0.6);
  border-radius: 50%;
  animation: particleFloat linear infinite;
}

@keyframes particleFloat {
  0% {
    transform: translateY(100vh) translateX(0) scale(0);
    opacity: 0;
  }
  10% {
    opacity: 1;
    transform: scale(1);
  }
  90% {
    opacity: 1;
  }
  100% {
    transform: translateY(-100px) translateX(100px) scale(0);
    opacity: 0;
  }
}

/* 光晕效果 */
.light-orbs {
  position: absolute;
  width: 100%;
  height: 100%;
  pointer-events: none;
}

.orb {
  position: absolute;
  border-radius: 50%;
  filter: blur(40px);
  animation: orbFloat 15s ease-in-out infinite;
}

.orb-1 {
  width: 200px;
  height: 200px;
  background: radial-gradient(circle, rgba(255, 154, 158, 0.3), transparent);
  top: 20%;
  left: 10%;
  animation-delay: 0s;
}

.orb-2 {
  width: 150px;
  height: 150px;
  background: radial-gradient(circle, rgba(102, 126, 234, 0.3), transparent);
  top: 60%;
  right: 15%;
  animation-delay: 5s;
}

.orb-3 {
  width: 100px;
  height: 100px;
  background: radial-gradient(circle, rgba(240, 147, 251, 0.3), transparent);
  bottom: 30%;
  left: 60%;
  animation-delay: 10s;
}

@keyframes orbFloat {
  0%, 100% {
    transform: translateY(0) translateX(0) scale(1);
  }
  33% {
    transform: translateY(-30px) translateX(20px) scale(1.1);
  }
  66% {
    transform: translateY(20px) translateX(-15px) scale(0.9);
  }
}

/* 浮动爱心动画 */
.floating-hearts {
  position: absolute;
  width: 100%;
  height: 100%;
  pointer-events: none;
}

.heart {
  position: absolute;
  font-size: 20px;
  animation: floatUp linear infinite;
  opacity: 0.8;
  filter: drop-shadow(0 0 10px rgba(255, 107, 129, 0.5));
}

@keyframes floatUp {
  0% {
    transform: translateY(100vh) rotate(0deg) scale(0.5);
    opacity: 0;
  }
  10% {
    opacity: 1;
    transform: scale(1);
  }
  90% {
    opacity: 1;
  }
  100% {
    transform: translateY(-100px) rotate(360deg) scale(0.5);
    opacity: 0;
  }
}

/* 简化的Banner装饰 */
.banner-decoration {
  position: absolute;
  top: 50%;
  left: 50%;
  transform: translate(-50%, -50%);
  text-align: center;
  color: white;
  z-index: 10;
}

.decoration-text {
  font-size: 2.5rem;
  font-weight: 300;
  opacity: 0.3;
  letter-spacing: 8px;
  text-transform: uppercase;
  animation: decorationFloat 6s ease-in-out infinite;
}

@keyframes decorationFloat {
  0%, 100% {
    opacity: 0.3;
    transform: translateY(0);
  }
  50% {
    opacity: 0.5;
    transform: translateY(-10px);
  }
}

/* 中间爱心区域 */
.center-heart {
  text-align: center;
  display: flex;
  flex-direction: column;
  align-items: center;
  justify-content: center;
}

.heart-icon {
  font-size: 4rem;
  animation: heartBeat 2s ease-in-out infinite;
  margin-bottom: 10px;
  filter: drop-shadow(0 0 20px rgba(255, 107, 129, 0.6));
}

.heart-text {
  font-size: 1.5rem;
  font-weight: 600;
  color: rgba(255, 255, 255, 0.9);
  text-shadow: 0 2px 4px rgba(0,0,0,0.3);
  letter-spacing: 2px;
  animation: textGlow 2s ease-in-out infinite;
}

@keyframes heartBeat {
  0%, 100% { transform: scale(1); }
  50% { transform: scale(1.1); }
}

/* 独立时间显示区域 */
.time-section-standalone {
  width: 100%;
  padding: 60px 20px 40px;
  position: relative;
  z-index: 10;
}

.time-container-standalone {
  max-width: 1000px;
  margin: 0 auto;
  text-align: center;
}

/* 独立区域标题 */
.time-main-title {
  margin-bottom: 40px;
}

.love-main-title-standalone {
  font-size: 3rem;
  font-weight: 800;
  margin-bottom: 1.5rem;
  line-height: 1.2;
}

.love-main-title-standalone .title-word {
  display: inline-block;
  background: linear-gradient(45deg, #667eea, #764ba2);
  -webkit-background-clip: text;
  -webkit-text-fill-color: transparent;
  background-clip: text;
  background-size: 200% 200%;
  animation: titleGlow 3s ease-in-out infinite, wordFloat 2s ease-in-out infinite;
  margin: 0 0.2em;
  text-shadow: 0 0 20px rgba(102, 126, 234, 0.3);
  filter: drop-shadow(0 2px 4px rgba(0,0,0,0.2));
}

.title-decoration-standalone {
  display: flex;
  align-items: center;
  justify-content: center;
  margin: 1rem 0;
  gap: 1rem;
}

.title-decoration-standalone .decoration-line {
  width: 60px;
  height: 2px;
  background: linear-gradient(90deg, transparent, rgba(102, 126, 234, 0.6), transparent);
  animation: lineShimmer 2s ease-in-out infinite;
}

.title-decoration-standalone .decoration-heart {
  font-size: 1.5rem;
  animation: heartPulse 1.5s ease-in-out infinite;
  filter: drop-shadow(0 0 10px rgba(255, 107, 129, 0.8));
}

.love-subtitle-standalone {
  font-size: 1.5rem;
  font-weight: 300;
  color: #666;
  letter-spacing: 2px;
  margin: 0;
}

/* 独立时间显示 */
.time-display-standalone {
  background: linear-gradient(135deg, rgba(255, 255, 255, 0.9), rgba(255, 255, 255, 0.7));
  backdrop-filter: blur(20px);
  border-radius: 30px;
  padding: 40px;
  border: 1px solid rgba(255, 255, 255, 0.3);
  box-shadow: 0 20px 40px rgba(0, 0, 0, 0.1);
  margin-top: 30px;
}

.love-time-title-standalone {
  font-size: 1.8rem;
  font-weight: 600;
  letter-spacing: 1px;
  background: linear-gradient(45deg, #ff9a9e, #fecfef, #fecfef, #ff9a9e);
  -webkit-background-clip: text;
  -webkit-text-fill-color: transparent;
  background-clip: text;
  background-size: 400%;
  animation: jianBian 8s linear infinite alternate;
  margin-bottom: 30px;
}

.love-time-standalone {
  display: flex;
  justify-content: center;
  align-items: center;
  flex-wrap: wrap;
  gap: 20px;
  margin: 30px 0;
  font-family: Inter, Avenir, Helvetica, Arial, sans-serif;
}

.time-block-standalone {
  display: flex;
  flex-direction: column;
  align-items: center;
  background: linear-gradient(135deg, rgba(255, 154, 158, 0.2), rgba(254, 207, 239, 0.2));
  border-radius: 20px;
  padding: 25px 20px;
  min-width: 120px;
  backdrop-filter: blur(10px);
  border: 1px solid rgba(255, 255, 255, 0.3);
  box-shadow: 0 10px 30px rgba(0, 0, 0, 0.1);
  transition: all 0.3s ease;
}

.time-block-standalone:hover {
  transform: translateY(-5px);
  box-shadow: 0 20px 40px rgba(0, 0, 0, 0.15);
}

.love-time-item-standalone {
  font-size: 3rem;
  font-weight: 700;
  background: linear-gradient(45deg, #ff6b81, #ff9a9e);
  -webkit-background-clip: text;
  -webkit-text-fill-color: transparent;
  background-clip: text;
  text-shadow: 0 2px 4px rgba(0,0,0,0.1);
  font-family: Inter, Avenir, Helvetica, Arial, sans-serif;
  line-height: 1;
  margin: 10px 0;
}

.time-unit-standalone {
  font-size: 1.2rem;
  color: #666;
  font-weight: 500;
  margin-top: 5px;
}

.time-message-standalone {
  text-align: center;
  margin-top: 30px;
  padding: 20px;
  background: linear-gradient(135deg, rgba(255, 107, 129, 0.1), rgba(255, 154, 158, 0.1));
  border-radius: 25px;
  border: 1px solid rgba(255, 107, 129, 0.2);
}

.time-message-standalone p {
  font-size: 1.4rem;
  color: #ff6b81;
  margin: 0;
  font-weight: 500;
  letter-spacing: 1px;
}

/* 中间标题 */
.center-title {
  margin-bottom: 30px;
}

.love-main-title-center {
  font-size: 2.5rem;
  font-weight: 800;
  margin-bottom: 1rem;
  line-height: 1.2;
}

.love-main-title-center .title-word {
  display: inline-block;
  background: linear-gradient(45deg, #ff9a9e, #fecfef, #fecfef, #ff9a9e);
  -webkit-background-clip: text;
  -webkit-text-fill-color: transparent;
  background-clip: text;
  background-size: 200% 200%;
  animation: titleGlow 3s ease-in-out infinite, wordFloat 2s ease-in-out infinite;
  margin: 0 0.2em;
  text-shadow: 0 0 20px rgba(255, 255, 255, 0.5);
  filter: drop-shadow(0 2px 4px rgba(0,0,0,0.3));
}

.title-decoration-center {
  display: flex;
  align-items: center;
  justify-content: center;
  margin: 1rem 0;
  gap: 1rem;
}

.title-decoration-center .decoration-line {
  width: 40px;
  height: 2px;
  background: linear-gradient(90deg, transparent, rgba(255, 255, 255, 0.8), transparent);
  animation: lineShimmer 2s ease-in-out infinite;
}

.title-decoration-center .decoration-heart {
  font-size: 1.2rem;
  animation: heartPulse 1.5s ease-in-out infinite;
  filter: drop-shadow(0 0 8px rgba(255, 107, 129, 0.8));
}

.love-subtitle-center {
  font-size: 1.2rem;
  font-weight: 300;
  opacity: 0.9;
  letter-spacing: 2px;
  color: rgba(255, 255, 255, 0.9);
  text-shadow: 0 1px 2px rgba(0,0,0,0.3);
}

@keyframes titleGlow {
  0%, 100% {
    background-position: 0% 50%;
  }
  50% {
    background-position: 100% 50%;
  }
}

@keyframes wordFloat {
  0%, 100% { transform: translateY(0); }
  50% { transform: translateY(-3px); }
}

@keyframes lineShimmer {
  0%, 100% { opacity: 0.5; }
  50% { opacity: 1; }
}

/* 中间时间显示 */
.time-display-center {
  margin-top: 20px;
}

.love-time-title-center {
  font-size: 1.2rem;
  font-weight: 600;
  letter-spacing: 1px;
  text-align: center;
  background: linear-gradient(45deg, #ff9a9e, #fecfef, #fecfef, #ff9a9e);
  -webkit-background-clip: text;
  -webkit-text-fill-color: transparent;
  background-clip: text;
  background-size: 400%;
  animation: jianBian 8s linear infinite alternate;
  margin-bottom: 20px;
  color: rgba(255, 255, 255, 0.9);
}

.title-icon {
  display: inline-block;
  animation: iconFloat 2s ease-in-out infinite;
  margin: 0 5px;
}

.love-time-center {
  display: flex;
  justify-content: center;
  align-items: center;
  flex-wrap: wrap;
  gap: 10px;
  margin: 20px 0;
  font-family: Inter, Avenir, Helvetica, Arial, sans-serif;
}

.time-block-center {
  display: flex;
  flex-direction: column;
  align-items: center;
  background: linear-gradient(135deg, rgba(255, 154, 158, 0.2), rgba(254, 207, 239, 0.2));
  border-radius: 12px;
  padding: 12px 8px;
  min-width: 60px;
  backdrop-filter: blur(10px);
  border: 1px solid rgba(255, 255, 255, 0.3);
  box-shadow: 0 4px 15px rgba(0, 0, 0, 0.1);
  transition: all 0.3s ease;
}

.time-block-center:hover {
  transform: translateY(-2px);
  box-shadow: 0 8px 20px rgba(0, 0, 0, 0.15);
}

.love-time-item-center {
  font-size: 2rem;
  font-weight: 700;
  background: linear-gradient(45deg, #ff6b81, #ff9a9e);
  -webkit-background-clip: text;
  -webkit-text-fill-color: transparent;
  background-clip: text;
  text-shadow: 0 1px 2px rgba(0,0,0,0.1);
  font-family: Inter, Avenir, Helvetica, Arial, sans-serif;
  line-height: 1;
  margin: 5px 0;
}

.time-unit-center {
  font-size: 0.9rem;
  color: rgba(255, 255, 255, 0.8);
  font-weight: 500;
  margin-top: 2px;
}

.time-message-center {
  text-align: center;
  margin-top: 20px;
  padding: 12px;
  background: linear-gradient(135deg, rgba(255, 107, 129, 0.1), rgba(255, 154, 158, 0.1));
  border-radius: 15px;
  border: 1px solid rgba(255, 107, 129, 0.2);
}

.time-message-center p {
  font-size: 1rem;
  color: rgba(255, 255, 255, 0.9);
  margin: 0;
  font-weight: 500;
  letter-spacing: 1px;
}

@keyframes iconFloat {
  0%, 100% { transform: translateY(0); }
  50% { transform: translateY(-3px); }
}

.banner-title2 {
  animation: title-scale 1s;
  position: absolute;
  top: 12.5rem;
  padding: 0 0.5rem;
  width: 100%;
  font-size: 2.5rem;
  text-align: center;
  color: #eee;
}

.photo-container {
  padding: 20px;
}

.masonry-grid {
  display: grid;
  grid-template-columns: repeat(auto-fill, minmax(250px, 1fr));
  grid-gap: 20px;
  grid-auto-flow: dense;
}

.masonry-item {
  break-inside: avoid;
  margin-bottom: 20px;
}

.photo-card {
  position: relative;
  border-radius: 8px;
  overflow: hidden;
  cursor: pointer;
  transition: transform 0.3s ease;
}

.photo-card:hover {
  transform: scale(1.02);
}

.photo-image {
  width: 100%;
  height: 100%;
  object-fit: cover;
}

.photo-overlay {
  position: absolute;
  bottom: 0;
  left: 0;
  right: 0;
  background: linear-gradient(transparent, rgba(0, 0, 0, 0.7));
  padding: 15px;
  opacity: 0;
  transition: opacity 0.3s ease;
}

.photo-card:hover .photo-overlay {
  opacity: 1;
}

.photo-title {
  color: white;
  font-size: 14px;
}

.photo-loading {
  display: flex;
  justify-content: center;
  align-items: center;
  height: 200px;
  background: #f5f5f5;
}

.preview-container {
  position: fixed;
  top: 0;
  left: 0;
  right: 0;
  bottom: 0;
  background: rgba(0, 0, 0, 0.9);
  display: flex;
  justify-content: center;
  align-items: center;
}

.preview-content {
  position: relative;
  max-width: 90vw;
  max-height: 90vh;
}

.preview-image {
  max-width: 100%;
  max-height: 100%;
}

.preview-caption {
  position: absolute;
  bottom: -40px;
  left: 0;
  right: 0;
  text-align: center;
  color: white;
  padding: 10px;
}

.preview-close {
  position: absolute;
  top: 20px;
  right: 20px;
  color: white;
  z-index: 1;
}

.preview-nav {
  position: absolute;
  top: 50%;
  transform: translateY(-50%);
  color: white;
  z-index: 1;
}

.preview-prev {
  left: 20px;
}

.preview-next {
  right: 20px;
}

.preview-loading {
  display: flex;
  justify-content: center;
  align-items: center;
  height: 100%;
}

.love-wrap {
  width: 90%;
  max-width: 1100px;
  backdrop-filter: blur(25px);
  background: linear-gradient(135deg,
    rgba(255, 255, 255, 0.25),
    rgba(255, 255, 255, 0.15),
    rgba(255, 255, 255, 0.2)
  );
  border-radius: 2.5em;
  display: flex;
  align-items: center;
  justify-content: center;
  padding: 40px;
  position: absolute;
  left: 0;
  right: 0;
  top: 70px;
  margin: 0 auto;
  z-index: 20;
  border: 1px solid rgba(255, 255, 255, 0.4);
  box-shadow:
    0 25px 50px rgba(0, 0, 0, 0.15),
    0 10px 30px rgba(255, 255, 255, 0.1) inset,
    0 0 0 1px rgba(255, 255, 255, 0.2) inset;
  overflow: hidden;
  min-height: 280px;
}

.love-wrap::before {
  content: '';
  position: absolute;
  top: 0;
  left: -100%;
  width: 100%;
  height: 100%;
  background: linear-gradient(90deg,
    transparent,
    rgba(255, 255, 255, 0.1),
    transparent
  );
  animation: wrapShimmer 8s ease-in-out infinite;
}

@keyframes wrapShimmer {
  0% { left: -100%; }
  50% { left: 100%; }
  100% { left: -100%; }
}

/* 内容包装器 */
.love-content-wrapper {
  display: flex;
  align-items: center;
  justify-content: center;
  width: 100%;
  height: 100%;
  position: relative;
  z-index: 2;
  gap: 40px;
}

/* 背景装饰圆圈 */
.love-bg-decoration {
  position: absolute;
  width: 100%;
  height: 100%;
  pointer-events: none;
  overflow: hidden;
  border-radius: 3em;
}

.bg-circle {
  position: absolute;
  border-radius: 50%;
  filter: blur(20px);
  animation: circleFloat 20s ease-in-out infinite;
}

.bg-circle-1 {
  width: 100px;
  height: 100px;
  background: radial-gradient(circle, rgba(255, 154, 158, 0.2), transparent);
  top: 10%;
  left: 5%;
  animation-delay: 0s;
}

.bg-circle-2 {
  width: 80px;
  height: 80px;
  background: radial-gradient(circle, rgba(102, 126, 234, 0.2), transparent);
  bottom: 15%;
  right: 10%;
  animation-delay: 7s;
}

.bg-circle-3 {
  width: 60px;
  height: 60px;
  background: radial-gradient(circle, rgba(240, 147, 251, 0.2), transparent);
  top: 60%;
  left: 80%;
  animation-delay: 14s;
}

@keyframes circleFloat {
  0%, 100% {
    transform: translateY(0) translateX(0) scale(1);
    opacity: 0.3;
  }
  33% {
    transform: translateY(-20px) translateX(10px) scale(1.2);
    opacity: 0.6;
  }
  66% {
    transform: translateY(10px) translateX(-15px) scale(0.8);
    opacity: 0.4;
  }
}

/* 人物容器 */
.love-person {
  display: flex;
  flex-direction: column;
  align-items: center;
  justify-content: center;
  position: relative;
  z-index: 2;
  flex: 0 0 200px;
  width: 200px;
  text-align: center;
}

/* 头像容器 */
.avatar-container {
  position: relative;
  margin-bottom: 25px;
}

.avatar-frame {
  position: relative;
  display: inline-block;
}

/* 头像闪烁装饰 */
.avatar-sparkles {
  position: absolute;
  width: 100%;
  height: 100%;
  pointer-events: none;
}

.sparkle {
  position: absolute;
  font-size: 16px;
  animation: sparkleFloat 3s ease-in-out infinite;
}

.sparkle-1 {
  top: -10px;
  right: -10px;
  animation-delay: 0s;
}

.sparkle-2 {
  bottom: -10px;
  left: -10px;
  animation-delay: 1s;
}

.sparkle-3 {
  top: 50%;
  right: -20px;
  animation-delay: 2s;
}

@keyframes sparkleFloat {
  0%, 100% {
    transform: translateY(0) scale(1);
    opacity: 0.7;
  }
  50% {
    transform: translateY(-10px) scale(1.2);
    opacity: 1;
  }
}

/* 人物信息 */
.person-info {
  text-align: center;
  position: relative;
  display: flex;
  flex-direction: column;
  align-items: center;
  justify-content: center;
  width: 100%;
}

.person-quote {
  font-size: 14px;
  color: rgba(255, 255, 255, 0.8);
  font-style: italic;
  margin-top: 8px;
  padding: 8px 16px;
  background: rgba(255, 255, 255, 0.1);
  border-radius: 20px;
  backdrop-filter: blur(10px);
  border: 1px solid rgba(255, 255, 255, 0.2);
  max-width: 200px;
}

/* 头像光环 */
.avatar-ring {
  position: absolute;
  top: -10px;
  left: -10px;
  right: -10px;
  bottom: -10px;
  border: 3px solid transparent;
  border-radius: 50%;
  background: linear-gradient(45deg, #ff9a9e, #fecfef, #fecfef, #ff9a9e);
  background-size: 400% 400%;
  animation: gradientRotate 3s ease infinite;
  z-index: -1;
}

/* 头像发光效果 */
.avatar-glow {
  position: absolute;
  top: -15px;
  left: -15px;
  right: -15px;
  bottom: -15px;
  border-radius: 50%;
  background: radial-gradient(circle, rgba(255, 154, 158, 0.3) 0%, transparent 70%);
  animation: pulse 2s ease-in-out infinite;
  z-index: -2;
}

@keyframes gradientRotate {
  0% { background-position: 0% 50%; }
  50% { background-position: 100% 50%; }
  100% { background-position: 0% 50%; }
}

@keyframes pulse {
  0%, 100% { transform: scale(1); opacity: 0.7; }
  50% { transform: scale(1.1); opacity: 1; }
}

/* 中间爱心区域 */
.love-center {
  display: flex;
  flex-direction: column;
  align-items: center;
  justify-content: center;
  position: relative;
  z-index: 3;
  flex: 1;
  max-width: 450px;
  width: 100%;
}

.heart-container {
  position: relative;
  margin-bottom: 25px;
}

.heart-frame {
  position: relative;
  display: inline-block;
}

.heart-pulse {
  position: absolute;
  top: -15px;
  left: -15px;
  right: -15px;
  bottom: -15px;
  border: 3px solid #ff6b81;
  border-radius: 50%;
  animation: heartPulse 2s ease-in-out infinite;
}

.heart-rings {
  position: absolute;
  top: 50%;
  left: 50%;
  transform: translate(-50%, -50%);
  pointer-events: none;
}

.ring {
  position: absolute;
  border: 2px solid rgba(255, 107, 129, 0.3);
  border-radius: 50%;
  animation: ringExpand 3s ease-in-out infinite;
}

.ring-1 {
  width: 160px;
  height: 160px;
  margin: -80px 0 0 -80px;
  animation-delay: 0s;
}

.ring-2 {
  width: 200px;
  height: 200px;
  margin: -100px 0 0 -100px;
  animation-delay: 1s;
}

.ring-3 {
  width: 240px;
  height: 240px;
  margin: -120px 0 0 -120px;
  animation-delay: 2s;
}

.heart-text {
  position: absolute;
  bottom: -35px;
  left: 50%;
  transform: translateX(-50%);
  font-size: 16px;
  font-weight: 600;
  color: rgba(255, 255, 255, 0.9);
  text-shadow: 0 2px 4px rgba(0,0,0,0.3);
  letter-spacing: 2px;
  animation: textGlow 2s ease-in-out infinite;
}

@keyframes heartPulse {
  0%, 100% {
    transform: scale(1);
    opacity: 1;
    border-color: #ff6b81;
  }
  50% {
    transform: scale(1.3);
    opacity: 0.3;
    border-color: #ff9a9e;
  }
}

@keyframes ringExpand {
  0% {
    transform: scale(0.8);
    opacity: 0;
  }
  50% {
    opacity: 0.6;
  }
  100% {
    transform: scale(1.2);
    opacity: 0;
  }
}

@keyframes textGlow {
  0%, 100% {
    text-shadow: 0 2px 4px rgba(0,0,0,0.3);
  }
  50% {
    text-shadow: 0 2px 4px rgba(0,0,0,0.3), 0 0 20px rgba(255, 107, 129, 0.5);
  }
}

/* 连接线 */
.love-connection {
  position: absolute;
  top: 50%;
  left: -150px;
  right: -150px;
  height: 2px;
  z-index: -1;
}

.connection-line {
  width: 100%;
  height: 2px;
  background: linear-gradient(90deg, transparent, #ff6b81, transparent);
  animation: lineGlow 2s ease-in-out infinite;
}

.connection-hearts {
  position: absolute;
  top: -10px;
  left: 0;
  right: 0;
  display: flex;
  justify-content: space-between;
  align-items: center;
}

.mini-heart {
  font-size: 16px;
  animation: bounce 1s ease-in-out infinite;
}

.mini-heart:nth-child(2) {
  animation-delay: 0.3s;
}

.mini-heart:nth-child(3) {
  animation-delay: 0.6s;
}

@keyframes bounce {
  0%, 100% { transform: translateY(0); }
  50% { transform: translateY(-10px); }
}

@keyframes lineGlow {
  0%, 100% { opacity: 0.5; }
  50% { opacity: 1; }
}

.love-avatar {
  border: rgba(255, 255, 255, 0.2) 4px solid;
  width: 180px;
  height: 180px;
}

.love-title {
  margin-top: 15px;
  text-align: center;
  font-size: 28px;
  font-weight: 700;
  color: #fff;
  text-shadow: 0 2px 4px rgba(0,0,0,0.3);
  letter-spacing: 2px;
}

.love-role {
  font-size: 16px;
  color: rgba(255, 255, 255, 0.9);
  margin-top: 8px;
  padding: 6px 16px;
  background: rgba(255, 255, 255, 0.2);
  border-radius: 20px;
  backdrop-filter: blur(10px);
  border: 1px solid rgba(255, 255, 255, 0.3);
}


.love-img {
  animation: imgScale 2s linear infinite;
  width: 120px;
  height: 120px;
}

 /* #bannerWave1 {
  height: 84px;
  background: var(--bannerWave1);
  position: absolute;
  width: 200%; 
  bottom: 0;
  z-index: 10;
  animation: gradientBG 120s linear infinite;
  left: -50%;  
}

#bannerWave2 {
  height: 100px;
  background: var(--bannerWave2);
  position: absolute;
  width: 400%; 
  bottom: 0;
  z-index: 5;
  animation: gradientBG 120s linear infinite;
  left: -150%; 
}
*/

.love-content {
  max-width: 1200px;
  overflow: hidden;
  margin: 20px auto 0;
  user-select: none;
  position: relative;
  left: auto;
  top: auto;
  transform: none;
}

.padfix {
  position: relative;
  top: 0;
  width: 100%;
  padding: 20px;
  margin-top: 10px;
}

.card-container {
  max-width: 1500px;
  margin: 20px auto 40px;
  position: relative;
  z-index: 1;
}

/* 时间区域 */
.time-section {
  margin: 40px 0;
}

.time-container {
  background: linear-gradient(135deg, rgba(255, 255, 255, 0.1), rgba(255, 255, 255, 0.05));
  backdrop-filter: blur(15px);
  border-radius: 30px;
  padding: 40px;
  border: 1px solid rgba(255, 255, 255, 0.2);
  box-shadow: 0 15px 35px rgba(0, 0, 0, 0.1);
}

.love-time-title1 {
  font-size: 2.2rem;
  font-weight: 600;
  letter-spacing: 0.2rem;
  line-height: 4rem;
  text-align: center;
  background-image: linear-gradient(45deg, #ff9a9e, #fecfef, #fecfef, #ff9a9e);
  -webkit-background-clip: text;
  background-clip: text;
  color: transparent;
  background-size: 400%;
  animation: jianBian 8s linear infinite alternate;
  margin-bottom: 30px;
}

.title-icon {
  display: inline-block;
  animation: iconFloat 2s ease-in-out infinite;
  margin: 0 10px;
}

@keyframes iconFloat {
  0%, 100% { transform: translateY(0); }
  50% { transform: translateY(-5px); }
}


.love-time-title2 {
  text-align: center;
  font-size: 1.5rem;
  line-height: 4rem;
  font-weight: 600;
  letter-spacing: 2px;
}

.love-time1 {
  display: flex;
  justify-content: center;
  align-items: center;
  flex-wrap: wrap;
  gap: 20px;
  margin: 30px 0;
  font-family: Inter, Avenir, Helvetica, Arial, sans-serif;
}

.time-block {
  display: flex;
  flex-direction: column;
  align-items: center;
  background: linear-gradient(135deg, rgba(255, 154, 158, 0.2), rgba(254, 207, 239, 0.2));
  border-radius: 20px;
  padding: 20px 15px;
  min-width: 100px;
  backdrop-filter: blur(10px);
  border: 1px solid rgba(255, 255, 255, 0.3);
  box-shadow: 0 8px 25px rgba(0, 0, 0, 0.1);
  transition: all 0.3s ease;
}

.time-block:hover {
  transform: translateY(-5px);
  box-shadow: 0 15px 35px rgba(0, 0, 0, 0.15);
}

.time-label {
  font-size: 1.2rem;
  color: #666;
  margin-bottom: 5px;
}

.love-time1-item {
  font-size: 3.5rem;
  font-weight: 700;
  background: linear-gradient(45deg, #ff6b81, #ff9a9e);
  -webkit-background-clip: text;
  -webkit-text-fill-color: transparent;
  background-clip: text;
  text-shadow: 0 2px 4px rgba(0,0,0,0.1);
  font-family: Inter, Avenir, Helvetica, Arial, sans-serif;
  line-height: 1;
  margin: 10px 0;
}

.time-unit {
  font-size: 1.1rem;
  color: #888;
  font-weight: 500;
  margin-top: 5px;
}

.time-message {
  text-align: center;
  margin-top: 30px;
  padding: 20px;
  background: linear-gradient(135deg, rgba(255, 107, 129, 0.1), rgba(255, 154, 158, 0.1));
  border-radius: 25px;
  border: 1px solid rgba(255, 107, 129, 0.2);
  
}

.time-message p {
  font-size: 1.3rem;
  color: #ff6b81;
  margin: 0;
  font-weight: 500;
  letter-spacing: 1px;
  text-align: center;
  
}


.card-wrap {
  max-width: 1200px;
  margin: 0 auto;
  display: flex;
  flex-wrap: wrap;
  justify-content: space-around;
  gap: 20px;
  padding: 20px;
}

/* 卡片样式 */
.love-card {
  display: flex;
  align-items: center;
  padding: 30px;
  margin: 0;
  border-radius: 25px;
  width: 100%;
  max-width: 400px;
  cursor: pointer;
  transition: all 0.4s cubic-bezier(0.4, 0, 0.2, 1);
  background: linear-gradient(135deg, rgba(255, 255, 255, 0.9), rgba(255, 255, 255, 0.7));
  backdrop-filter: blur(20px);
  border: 1px solid rgba(255, 255, 255, 0.3);
  box-shadow: 0 10px 30px rgba(0, 0, 0, 0.1);
  position: relative;
  overflow: hidden;
}

.love-card::before {
  content: '';
  position: absolute;
  top: 0;
  left: -100%;
  width: 100%;
  height: 100%;
  background: linear-gradient(90deg, transparent, rgba(255, 255, 255, 0.4), transparent);
  transition: left 0.5s ease;
}

.love-card:hover::before {
  left: 100%;
}

.love-card:hover {
  transform: translateY(-10px) scale(1.02);
  box-shadow: 0 20px 40px rgba(0, 0, 0, 0.15);
}

.love-card.active {
  background: linear-gradient(135deg, rgba(255, 154, 158, 0.2), rgba(254, 207, 239, 0.2));
  border-color: #ff9a9e;
  transform: translateY(-5px);
}

/* 卡片图标 */
.card-icon-container {
  position: relative;
  margin-right: 25px;
}

.card-icon {
  width: 80px;
  height: 80px;
  border-radius: 20px;
  display: flex;
  align-items: center;
  justify-content: center;
  font-size: 2.5rem;
  position: relative;
  z-index: 2;
}

.timeline-icon {
  background: linear-gradient(135deg, #667eea, #764ba2);
}

.photo-icon {
  background: linear-gradient(135deg, #f093fb, #f5576c);
}

.blessing-icon {
  background: linear-gradient(135deg, #4facfe, #00f2fe);
}

.card-glow {
  position: absolute;
  top: -5px;
  left: -5px;
  right: -5px;
  bottom: -5px;
  border-radius: 25px;
  background: inherit;
  filter: blur(10px);
  opacity: 0.7;
  z-index: 1;
}

.icon-emoji {
  font-size: 2.5rem;
  filter: drop-shadow(0 2px 4px rgba(0,0,0,0.2));
}

/* 卡片内容 */
.card-right {
  flex: 1;
  margin-left: 20px;
}

.card-title {
  margin-bottom: 10px;
}

.title-gradient {
  font-size: 1.8rem;
  font-weight: 700;
  background: linear-gradient(45deg, #667eea, #764ba2);
  -webkit-background-clip: text;
  -webkit-text-fill-color: transparent;
  background-clip: text;
  letter-spacing: 1px;
}

.card-desc {
  font-size: 1.1rem;
  color: #666;
  line-height: 1.5;
  letter-spacing: 0.5px;
}

/* 卡片箭头 */
.card-arrow {
  font-size: 1.5rem;
  color: #999;
  transition: all 0.3s ease;
  margin-left: 15px;
}

.love-card:hover .card-arrow {
  color: #667eea;
  transform: translateX(5px);
}



/* 中等屏幕优化 */
@media (max-width: 1024px) and (min-width: 769px) {
  .love-wrap {
    width: 95%;
    max-width: 900px;
    padding: 35px 30px;
    left: 0;
    right: 0;
    margin: 0 auto;
  }

  .love-content-wrapper {
    gap: 30px;
  }

  .love-person {
    flex: 0 0 180px;
    width: 180px;
  }

  .center-content {
    max-width: 400px;
    padding: 20px 15px;
  }

  .love-main-title-center {
    font-size: 2.2rem;
  }

  .love-time-center {
    gap: 8px;
  }

  .time-block-center {
    min-width: 55px;
    padding: 12px 8px;
  }

  .love-time-item-center {
    font-size: 1.8rem;
  }
}

@media (max-width: 768px) {
  /* 头像区域移动端优化 */
  .love-wrap {
    width: 95%;
    max-width: 95%;
    padding: 20px 15px;
    flex-direction: column;
    gap: 20px;
    align-items: center;
    top: 100px;
    min-height: auto;
    left: 0;
    right: 0;
    margin: 0 auto;
  }

  .love-person {
    width: 100%;
    max-width: 160px;
    flex: none;
    display: flex;
    flex-direction: column;
    align-items: center;
    justify-content: center;
  }

  .love-center {
    order: -1; /* 将内容移到最上方 */
    margin: 0;
    width: 100%;
    flex: none;
  }

  /* 隐藏连接线在移动端 */
  .love-connection {
    display: none;
  }

  /* 重新排列：内容在上，两人在下方并排 */
  .love-content-wrapper {
    display: grid;
    grid-template-columns: 1fr 1fr;
    grid-template-rows: auto auto;
    gap: 15px;
    justify-items: center;
    align-items: center;
    width: 100%;
    height: auto;
    place-items: center;
  }

  .love-center {
    grid-column: 1 / -1;
    grid-row: 1;
    order: 0;
    margin-bottom: 10px;
  }

  .love-person:first-child {
    grid-column: 1;
    grid-row: 2;
  }

  .love-person:last-child {
    grid-column: 2;
    grid-row: 2;
  }

  /* 调整头像大小 */
  .avatar-container .love-avatar {
    width: 90px !important;
    height: 90px !important;
  }

  .love-title {
    font-size: 16px;
    margin-top: 8px;
  }

  .love-role {
    font-size: 12px;
    padding: 3px 8px;
  }

  .person-quote {
    font-size: 11px;
    max-width: 130px;
    padding: 4px 8px;
  }

  /* 中间内容区域移动端优化 */
  .center-content {
    padding: 15px;
    max-width: 100%;
    min-height: auto;
  }

  .love-main-title-center {
    font-size: 1.8rem;
  }

  .love-subtitle-center {
    font-size: 0.9rem;
  }

  .love-time-title-center {
    font-size: 0.9rem;
    margin-bottom: 15px;
  }

  .love-time-center {
    gap: 6px;
  }

  .time-block-center {
    min-width: 45px;
    padding: 8px 4px;
  }

  .love-time-item-center {
    font-size: 1.3rem;
  }

  .time-unit-center {
    font-size: 0.7rem;
  }

  .time-message-center {
    margin-top: 15px;
    padding: 8px;
  }

  .time-message-center p {
    font-size: 0.8rem;
  }

  .love-container {
    overflow-x: hidden;
    margin-top: 0;
  }

  .padfix {
    padding: 10px;
  }

  .card-wrap {
    padding: 10px;
  }

  /* 独立时间区域移动端优化 */
  .time-section-standalone {
    padding: 40px 15px 30px;
  }

  .love-main-title-standalone {
    font-size: 2.2rem;
  }

  .love-subtitle-standalone {
    font-size: 1.2rem;
  }

  .love-time-title-standalone {
    font-size: 1.4rem;
  }

  .love-time-standalone {
    gap: 15px;
  }

  .time-block-standalone {
    min-width: 90px;
    padding: 20px 15px;
  }

  .love-time-item-standalone {
    font-size: 2.2rem;
  }

  .time-unit-standalone {
    font-size: 1rem;
  }

  .time-message-standalone p {
    font-size: 1.2rem;
  }
}
.card-right {
    margin-left: 20px;
  }

  .card-title {
    font-size: 1.6rem;
    letter-spacing: 0.2rem;
    line-height: 3.5rem;
    font-weight: 700;
  }

  .card-desc {
    font-size: 1.1rem;
    letter-spacing: 0.2rem;
    color: #777777;
  }
.transformCenter {
  position: absolute;
  left: 50%;
  top: 50%;
  transform: translate(-50%, -160%);
}
.love-time1-item {
 display: inline-block;
 padding: 0 5px;
 font-weight: bold;
 color: #ff6b81;
 position: relative;
 perspective: 300px;
}

.love-time1-item.flip {
 animation: flipNumber 0.6s ease-in-out;
}

@keyframes flipNumber {
 0% {
  transform: rotateX(0deg);
 }
 50% {
  transform: rotateX(90deg);
 }
 100% {
  transform: rotateX(0deg);
 }
}

/* 时间线样式 */
.timeline-container {
  padding: 40px 20px;
  max-width: 1000px;
  margin: 0 auto;
}

.timeline-header {
  text-align: center;
  margin-bottom: 50px;
}

.timeline-main-title {
  font-size: 2.5rem;
  font-weight: 700;
  background: linear-gradient(45deg, #667eea, #764ba2);
  -webkit-background-clip: text;
  -webkit-text-fill-color: transparent;
  background-clip: text;
  margin-bottom: 15px;
  letter-spacing: 2px;
}

.timeline-subtitle {
  font-size: 1.2rem;
  color: #666;
  font-weight: 300;
  letter-spacing: 1px;
}

.custom-timeline {
  position: relative;
  padding: 20px 0;
}

.custom-timeline::before {
  content: '';
  position: absolute;
  left: 50%;
  top: 0;
  bottom: 0;
  width: 4px;
  background: linear-gradient(to bottom, #667eea, #764ba2);
  transform: translateX(-50%);
  border-radius: 2px;
}

.timeline-item {
  display: flex;
  align-items: center;
  margin-bottom: 60px;
  position: relative;
  animation: fadeInUp 0.6s ease-out;
}

.timeline-item:nth-child(even) {
  flex-direction: row-reverse;
}

.timeline-item:nth-child(even) .timeline-content {
  text-align: right;
  margin-right: 60px;
  margin-left: 0;
}

.timeline-item:nth-child(odd) .timeline-content {
  margin-left: 60px;
}

.timeline-dot {
  width: 80px;
  height: 80px;
  background: linear-gradient(135deg, #667eea, #764ba2);
  border-radius: 50%;
  display: flex;
  align-items: center;
  justify-content: center;
  position: relative;
  z-index: 2;
  box-shadow: 0 10px 30px rgba(102, 126, 234, 0.3);
  animation: pulse 2s ease-in-out infinite;
}

.dot-icon {
  font-size: 2rem;
  filter: drop-shadow(0 2px 4px rgba(0,0,0,0.2));
}

.timeline-content {
  flex: 1;
  background: linear-gradient(135deg, rgba(255, 255, 255, 0.9), rgba(255, 255, 255, 0.7));
  backdrop-filter: blur(15px);
  border-radius: 20px;
  padding: 30px;
  border: 1px solid rgba(255, 255, 255, 0.3);
  box-shadow: 0 15px 35px rgba(0, 0, 0, 0.1);
  position: relative;
  transition: all 0.3s ease;
}

.timeline-content:hover {
  transform: translateY(-5px);
  box-shadow: 0 20px 40px rgba(0, 0, 0, 0.15);
}

.timeline-content::before {
  content: '';
  position: absolute;
  top: 50%;
  width: 0;
  height: 0;
  border: 15px solid transparent;
  transform: translateY(-50%);
}

.timeline-item:nth-child(odd) .timeline-content::before {
  left: -30px;
  border-right-color: rgba(255, 255, 255, 0.9);
}

.timeline-item:nth-child(even) .timeline-content::before {
  right: -30px;
  border-left-color: rgba(255, 255, 255, 0.9);
}

.timeline-date {
  font-size: 1.1rem;
  color: #667eea;
  font-weight: 600;
  margin-bottom: 10px;
  letter-spacing: 1px;
}

.timeline-title {
  font-size: 1.5rem;
  font-weight: 700;
  color: #333;
  margin-bottom: 10px;
  letter-spacing: 1px;
}

.timeline-desc {
  font-size: 1.1rem;
  color: #666;
  line-height: 1.6;
  letter-spacing: 0.5px;
}

@keyframes fadeInUp {
  from {
    opacity: 0;
    transform: translateY(30px);
  }
  to {
    opacity: 1;
    transform: translateY(0);
  }
}


</style>

<style scoped>
/* 祝福板样式 */
.blessing-container {
  padding: 40px 20px;
  max-width: 1000px;
  margin: 0 auto;
}

.blessing-header {
  text-align: center;
  margin-bottom: 40px;
}

.blessing-main-title {
  font-size: 2.5rem;
  font-weight: 700;
  background: linear-gradient(45deg, #f093fb, #f5576c);
  -webkit-background-clip: text;
  -webkit-text-fill-color: transparent;
  background-clip: text;
  margin-bottom: 15px;
  letter-spacing: 2px;
}

.blessing-subtitle {
  font-size: 1.2rem;
  color: #666;
  font-weight: 300;
  letter-spacing: 1px;
}

.blessing-form {
  margin-bottom: 40px;
}

.form-container {
  background: linear-gradient(135deg, rgba(255, 255, 255, 0.9), rgba(255, 255, 255, 0.7));
  backdrop-filter: blur(15px);
  border-radius: 25px;
  padding: 30px;
  border: 1px solid rgba(255, 255, 255, 0.3);
  box-shadow: 0 15px 35px rgba(0, 0, 0, 0.1);
}

.blessing-input {
  margin-bottom: 20px;
}

.blessing-input :deep(.v-field) {
  background: rgba(255, 255, 255, 0.8) !important;
  border-radius: 15px !important;
  border: 2px solid rgba(240, 147, 251, 0.3) !important;
  transition: all 0.3s ease;
}

.blessing-input :deep(.v-field:hover) {
  border-color: rgba(240, 147, 251, 0.5) !important;
  box-shadow: 0 5px 15px rgba(240, 147, 251, 0.2);
}

.blessing-input :deep(.v-field--focused) {
  border-color: #f093fb !important;
  box-shadow: 0 8px 25px rgba(240, 147, 251, 0.3);
}

.blessing-wall {
  margin-top: 30px;
}

.blessing-stats {
  text-align: center;
  margin-bottom: 30px;
  padding: 15px;
  background: linear-gradient(135deg, rgba(240, 147, 251, 0.1), rgba(245, 87, 108, 0.1));
  border-radius: 20px;
  border: 1px solid rgba(240, 147, 251, 0.2);
}

.stats-text {
  font-size: 1.1rem;
  color: #f093fb;
  font-weight: 600;
  display: flex;
  align-items: center;
  justify-content: center;
  gap: 8px;
}

.blessing-list {
  display: grid;
  gap: 25px;
  grid-template-columns: repeat(auto-fill, minmax(350px, 1fr));
}
.heart-button {
    background: linear-gradient(45deg, #ff4b5c, #ff6b81);
    border: none;
    color: white;
    font-size: 18px;
    font-weight: bold;
    padding: 12px 24px;
    border-radius: 30px;
    cursor: pointer;
    transition: all 0.3s ease-in-out;
    display: flex;
    align-items: center;
    justify-content: center;
    gap: 8px;
    box-shadow: 0 4px 10px rgba(255, 75, 92, 0.4);
    position: relative;
    overflow: hidden;
    height: 50px;
    
}

.heart-button:hover {
    transform: scale(1.1);
    box-shadow: 0 6px 15px rgba(255, 75, 92, 0.6);
}

.heart-button:active {
    transform: scale(0.9);
}

.heart-button::before {
    content: '💖';
    position: absolute;
    font-size: 20px;
    opacity: 0;
    top: 50%;
    left: 50%;
    transform: translate(-50%, -50%) scale(2);
    transition: opacity 0.2s, transform 0.2s;
}

.heart-button:active::before {
    opacity: 1;
    transform: translate(-50%, -50%) scale(1);
}



.blessing-list {
  display: grid;
  gap: 16px;
  grid-template-columns: repeat(auto-fill, minmax(280px, 1fr));
}

.blessing-card {
  background: linear-gradient(135deg, rgba(255, 255, 255, 0.95), rgba(255, 255, 255, 0.85));
  backdrop-filter: blur(20px);
  border-radius: 20px;
  padding: 25px;
  border: 1px solid rgba(255, 255, 255, 0.3);
  box-shadow: 0 15px 35px rgba(0, 0, 0, 0.1);
  transition: all 0.4s cubic-bezier(0.4, 0, 0.2, 1);
  animation: fadeIn 0.6s ease-out;
  position: relative;
  overflow: hidden;
}

.blessing-card::before {
  content: '';
  position: absolute;
  top: 0;
  left: -100%;
  width: 100%;
  height: 100%;
  background: linear-gradient(90deg, transparent, rgba(240, 147, 251, 0.1), transparent);
  transition: left 0.6s ease;
}

.blessing-card:hover::before {
  left: 100%;
}

.blessing-card:hover {
  transform: translateY(-8px) scale(1.02);
  box-shadow: 0 25px 50px rgba(0, 0, 0, 0.15);
  border-color: rgba(240, 147, 251, 0.4);
}

.blessing-header-card {
  display: flex;
  align-items: center;
  margin-bottom: 20px;
  padding-bottom: 15px;
  border-bottom: 2px solid rgba(240, 147, 251, 0.1);
}

.blessing-avatar {
  width: 50px;
  height: 50px;
  background: linear-gradient(135deg, #f093fb, #f5576c);
  border-radius: 50%;
  display: flex;
  align-items: center;
  justify-content: center;
  margin-right: 15px;
  box-shadow: 0 5px 15px rgba(240, 147, 251, 0.3);
}

.blessing-info {
  flex: 1;
}

.blessing-author {
  font-size: 1.1rem;
  font-weight: 600;
  color: #333;
  margin-bottom: 5px;
}

.blessing-date {
  font-size: 0.9rem;
  color: #999;
}

.blessing-heart {
  font-size: 1.5rem;
  animation: heartBeat 1.5s ease-in-out infinite;
}

@keyframes heartBeat {
  0%, 100% { transform: scale(1); }
  50% { transform: scale(1.1); }
}

.blessing-content {
  font-size: 1.2rem;
  color: #444;
  line-height: 1.6;
  margin-bottom: 20px;
  font-style: italic;
  position: relative;
  padding: 15px;
  background: rgba(240, 147, 251, 0.05);
  border-radius: 15px;
  border-left: 4px solid #f093fb;
}

.blessing-decoration {
  display: flex;
  justify-content: center;
  gap: 10px;
  margin-top: 15px;
}

.decoration-heart {
  font-size: 1.2rem;
  animation: bounce 2s ease-in-out infinite;
}

.decoration-heart:nth-child(2) {
  animation-delay: 0.3s;
}

.decoration-heart:nth-child(3) {
  animation-delay: 0.6s;
}

.empty-blessing {
  text-align: center;
  padding: 60px 20px;
  color: #999;
}

.empty-icon {
  font-size: 4rem;
  margin-bottom: 20px;
  opacity: 0.7;
}

.empty-blessing p {
  font-size: 1.2rem;
  margin: 0;
}

@keyframes fadeIn {
  from {
    opacity: 0;
    transform: translateY(20px);
  }
  to {
    opacity: 1;
    transform: translateY(0);
  }
}

.v-card-text {
  font-size: 1.1em;
  color: #333;
  line-height: 1.5;
}

.v-card-subtitle {
  color: #666;
  font-size: 0.9em;
}

@media (max-width: 600px) {
  .blessing-form {
    flex-direction: column;
  }
  
  .blessing-form .v-btn {
    width: 100%;
  }
  .blessing-form .v-text-field {
    width: 100%;
  }
  
  .blessing-list {
    grid-template-columns: 1fr;
  }
}

/* 时间线和祝福板响应式设计 */
@media (max-width: 768px) {
  /* 时间线移动端适配 */
  .timeline-main-title {
    font-size: 2rem;
  }

  .custom-timeline::before {
    left: 30px;
  }

  .timeline-item {
    flex-direction: row !important;
    margin-bottom: 40px;
  }

  .timeline-item .timeline-content {
    text-align: left !important;
    margin-left: 80px !important;
    margin-right: 0 !important;
  }

  .timeline-content::before {
    left: -30px !important;
    right: auto !important;
    border-right-color: rgba(255, 255, 255, 0.9) !important;
    border-left-color: transparent !important;
  }

  .timeline-dot {
    width: 60px;
    height: 60px;
    position: absolute;
    left: 0;
  }

  .dot-icon {
    font-size: 1.5rem;
  }

  /* 祝福板移动端适配 */
  .blessing-main-title {
    font-size: 2rem;
  }

  .form-container {
    padding: 20px;
  }

  .blessing-card {
    padding: 20px;
  }

  .blessing-content {
    font-size: 1.1rem;
  }
}

@media (max-width: 480px) {
  /* 超小屏幕头像区域优化 */
  .love-wrap {
    padding: 20px 10px;
    gap: 15px;
  }

  .avatar-container .love-avatar {
    width: 80px !important;
    height: 80px !important;
  }

  .love-title {
    font-size: 16px;
    margin-top: 8px;
  }

  .love-role {
    font-size: 11px;
    padding: 3px 8px;
  }

  .person-quote {
    font-size: 10px;
    max-width: 120px;
    padding: 4px 8px;
  }

  .avatar-ring {
    top: -5px;
    left: -5px;
    right: -5px;
    bottom: -5px;
    border-width: 2px;
  }

  .avatar-glow {
    top: -8px;
    left: -8px;
    right: -8px;
    bottom: -8px;
  }

  /* 中间内容区域超小屏优化 */
  .center-content {
    padding: 12px;
  }

  .love-main-title-center {
    font-size: 1.8rem;
  }

  .love-subtitle-center {
    font-size: 0.9rem;
  }

  .love-time-title-center {
    font-size: 0.9rem;
    margin-bottom: 15px;
  }

  .love-time-center {
    gap: 6px;
  }

  .time-block-center {
    min-width: 45px;
    padding: 8px 4px;
  }

  .love-time-item-center {
    font-size: 1.3rem;
  }

  .time-unit-center {
    font-size: 0.7rem;
  }

  .time-message-center {
    padding: 8px;
    margin-top: 15px;
  }

  .time-message-center p {
    font-size: 0.8rem;
  }

  /* Banner装饰优化 */
  .decoration-text {
    font-size: 2rem;
    letter-spacing: 4px;
  }

  /* 时间线和祝福板 */
  .timeline-container,
  .blessing-container {
    padding: 20px 10px;
  }

  .timeline-main-title,
  .blessing-main-title {
    font-size: 1.8rem;
  }

  .timeline-subtitle,
  .blessing-subtitle {
    font-size: 1rem;
  }

  .timeline-content {
    padding: 20px;
  }

  .timeline-title {
    font-size: 1.3rem;
  }

  .timeline-desc {
    font-size: 1rem;
  }

  .blessing-card {
    padding: 15px;
  }

  .blessing-content {
    font-size: 1rem;
    padding: 10px;
  }
}

/* 极小屏幕优化 (小于375px) */
@media (max-width: 375px) {
  .love-wrap {
    /* 改为垂直布局 */
    width: 95%;
    max-width: 95%;
    display: flex;
    flex-direction: column;
    align-items: center;
    gap: 20px;
    padding: 20px 10px;
    top: 80px;
    left: 0;
    right: 0;
    margin: 0 auto;
  }

  .love-content-wrapper {
    display: flex;
    flex-direction: column;
    align-items: center;
    gap: 20px;
    width: 100%;
    height: auto;
  }

  .love-person {
    width: 100%;
    max-width: 140px;
  }

  .love-center {
    order: 0;
    margin: 0;
  }

  .avatar-container .love-avatar {
    width: 70px !important;
    height: 70px !important;
  }

  .love-title {
    font-size: 14px;
    margin-top: 6px;
  }

  .love-role {
    font-size: 10px;
    padding: 2px 6px;
    margin-top: 4px;
  }

  .person-quote {
    font-size: 9px;
    max-width: 100px;
    padding: 3px 6px;
  }

  /* 中间内容区域超小屏优化 */
  .center-content {
    padding: 12px;
    min-height: auto;
  }

  .love-main-title-center {
    font-size: 1.5rem;
  }

  .love-subtitle-center {
    font-size: 0.8rem;
  }

  .love-time-title-center {
    font-size: 0.8rem;
    margin-bottom: 12px;
  }

  .love-time-center {
    gap: 4px;
  }

  .time-block-center {
    min-width: 40px;
    padding: 6px 3px;
  }

  .love-time-item-center {
    font-size: 1.1rem;
  }

  .time-unit-center {
    font-size: 0.6rem;
  }

  .time-message-center {
    margin-top: 12px;
    padding: 6px;
  }

  .time-message-center p {
    font-size: 0.7rem;
  }

  /* Banner装饰优化 */
  .decoration-text {
    font-size: 1.8rem;
    letter-spacing: 3px;
  }

  .love-container {
    margin-top: 0;
  }

  /* 独立时间区域超小屏优化 */
  .time-section-standalone {
    padding: 30px 10px 20px;
  }

  .love-main-title-standalone {
    font-size: 1.8rem;
  }

  .love-subtitle-standalone {
    font-size: 1rem;
  }

  .love-time-title-standalone {
    font-size: 1.2rem;
  }

  .love-time-standalone {
    gap: 10px;
  }

  .time-block-standalone {
    min-width: 70px;
    padding: 15px 10px;
  }

  .love-time-item-standalone {
    font-size: 1.8rem;
  }

  .time-unit-standalone {
    font-size: 0.9rem;
  }

  .time-message-standalone {
    padding: 15px;
  }

  .time-message-standalone p {
    font-size: 1rem;
  }
}

/* 页面入场动画 */
.love-wrap,
.time-section,
.card-wrap {
  opacity: 0;
  transform: translateY(50px);
  transition: all 0.8s cubic-bezier(0.4, 0, 0.2, 1);
}

.love-wrap.animate-in,
.time-section.animate-in,
.card-wrap.animate-in {
  opacity: 1;
  transform: translateY(0);
}

/* 全局页面样式优化 */
body.love-page-loaded {
  overflow-x: hidden;
}

/* 确保页面内容居中 */
.love-container {
  display: flex;
  flex-direction: column;
  align-items: center;
}

.myCenter {
  width: 100%;
  max-width: 1200px;
  margin: 0 auto;
}

/* 滚动条美化 */
::-webkit-scrollbar {
  width: 8px;
}

::-webkit-scrollbar-track {
  background: linear-gradient(135deg, rgba(102, 126, 234, 0.1), rgba(240, 147, 251, 0.1));
  border-radius: 4px;
}

::-webkit-scrollbar-thumb {
  background: linear-gradient(135deg, #667eea, #764ba2);
  border-radius: 4px;
  transition: all 0.3s ease;
}

::-webkit-scrollbar-thumb:hover {
  background: linear-gradient(135deg, #764ba2, #f093fb);
}

/* 选中文本样式 */
::selection {
  background: linear-gradient(135deg, rgba(255, 154, 158, 0.3), rgba(240, 147, 251, 0.3));
  color: #333;
}

::-moz-selection {
  background: linear-gradient(135deg, rgba(255, 154, 158, 0.3), rgba(240, 147, 251, 0.3));
  color: #333;
}
</style>

