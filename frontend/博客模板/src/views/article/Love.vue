<template>
  
  <!-- banner -->
  <div class="banner2" :style="cover">
    <!--<h1 class="banner-title2">Love</h1>-->
  </div>
  <!-- 对象-->
  <div class="love-wrap transformCenter ">
    <div>
      <v-avatar size="110" class="love-avatar" :image="imgpath" />

      <div class="love-title">
        {{ love.manName }}
      </div>
    </div>
    <div>
      <v-avatar size="110" class="love-img" :image="img" />
      <!-- 对象<img class="love-img" :src="love.manCover" alt="心心">-->
    </div>
    <div>
      <v-avatar size="110" class="love-avatar" :image="love.manCover" />

      <div class="love-title">
        {{ love.womanName }}
      </div>
    </div>
  </div>

  <div id="bannerWave1"></div>
  <div id="bannerWave2"></div>
  <div class="love-container ">
    <div class="myCenter love-content">
      <!-- 时间 -->
      <div>
        <!-- 计时 -->
        <div>
          <div class="love-time-title1">
            这是我们一起走过的
          </div>
          <div class="love-time1">
            第
            <span class="love-time1-item">{{ timing.year }}</span>
            年
            <span class="love-time1-item">{{ timing.month }}</span>
            月
            <span class="love-time1-item">{{ timing.day }}</span>
            日
            <span class="love-time1-item">{{ timing.hour }}</span>
            时
            <span class="love-time1-item">{{ timing.minute }}</span>
            分
            <span class="love-time1-item">{{ timing.second }}</span>
            秒
          </div>
        </div>
        <!-- 倒计时 
          <div class="love-time-title2"
               v-if="!$common.isEmpty(love.countdownTitle) || !$common.isEmpty(love.countdownTime)">
            {{love.countdownTitle}}: {{countdownChange}}-->
      </div>
    </div>

    <div style="padding: 0 20px" class="padfix">
      <!-- 卡片 -->
      <div class="card-wrap" v-show="card !== 4">
        <div class="card-content shadow-box-mini" @click="changeCard(1)">
          <div>
            
            <v-avatar size="100" :image="imgpath" />
          </div>
          <div class="card-right">
            <div class="card-title">
              点点滴滴
            </div>
            <div class="card-desc">
              ☀️今朝有酒今朝醉
            </div>
          </div>
        </div>

        <div class="card-content shadow-box-mini" @click="changeCard(2)">
          <div>
            <v-avatar size="100" :image="imgpath" />
          </div>
          <div class="card-right">
            <div class="card-title">
              时光相册
            </div>
            <div class="card-desc">
              📸记录美好瞬间
            </div>
          </div>
        </div>

        <div class="card-content shadow-box-mini" @click="changeCard(3)">
          <div>
            <v-avatar size="100" :image="imgpath" />
          </div>
          <div class="card-right">
            <div class="card-title">
              祝福板
            </div>
            <div class="card-desc">
              📋写下对我们的祝福
            </div>
          </div>
        </div>
      </div>

      <div class="card-container">
        <div v-show="card === 1 ">
          
        </div>
        <!--<div v-show="card === 2 && !$common.isEmpty(photoTitleList)">
           标签 
          <div class="photo-title-warp" v-if="!$common.isEmpty(photoTitleList)">
            <div v-for="(item, index) in photoTitleList" :key="index"
              :class="{ isActive: photoPagination.classify === item.classify }" @click="changePhotoTitle(item.classify)">
              <proTag :info="item.classify + ' ' + item.count"
                :color="$constant.before_color_list[Math.floor(Math.random() * 6)]" style="margin: 12px">
              </proTag>
            </div>
          </div>

          <div class="photo-title">
            {{ photoPagination.classify }}
          </div>

          <photo :resourcePathList="photoList"></photo>
          <div class="pagination-wrap">
            <div @click="pagePhotos()" class="pagination" v-if="photoPagination.total !== photoList.length">
              下一页
            </div>
            <div v-else style="user-select: none">
              ~~到底啦~~
            </div>
          </div>
        </div>
        <div v-show="card === 3" class="comment-content">
          <comment :source="$constant.userId" :type="'love'" :userId="$constant.userId"></comment>
        </div>-->
      </div>

      
    </div>

  </div>
</template>

<script setup lang="ts">
import { Timeline, TimelineTitle, TimelineItem } from "vue3-cute-component";
import { ref, reactive } from "vue";
import imgpath from "../../assets/images/tx.jpg";
import img from "../../assets/images/Sara11704792567121932.svg";


let current = ref(1);
const cover = ref(
  `background: url(https://oss.okay123.top/oss//2023/07/13/AYR7ORDgqQ.jpg) center center / cover no-repeat`
);
const love = reactive({
  manName: "MAN",
  womanCover: "",
  womanName: "WOMEN",
  manCover: imgpath,
  path: "E:\\VSWork\\MyGitHub\\个人博客网站Blog\\可乐不加冰Easy.Admin\\src\\frontend\\博客模板\\Sara11704792567121932.svg"

});
const card = ref<number>(0);
const timing = ref({
  year: 0,
  month: 0,
  day: 0,
  hour: 0,
  minute: 0,
  second: 0
});

const changeCard = (card: number) => {
        
          card = 1;
       
      };

const getLove = () => {

  let diff = timeDiff('2021-08-09');
  timing.value.year = diff.diffYear;
  timing.value.month = diff.diffMonth;
  timing.value.day = diff.diffDay;
  timing.value.hour = diff.diffHour;
  timing.value.minute = diff.diffMinute;
  timing.value.second = diff.diffSecond;
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
  getLove();

}, 1000);
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
  background-image: linear-gradient(to right, rgba(37, 82, 110, 0.1) 1px, var(--background) 1px), linear-gradient(to bottom, rgba(37, 82, 110, 0.1) 1px, var(--background) 1px);
  background-size: 3rem 3rem;
  /*background: var(--background);*/
}

.banner2 {
  position: absolute;
  background-color: #49b1f5 !important;
  top: -60px;
  left: 0;
  right: 0;
  height: 400px;
  animation: header-effect 1s;
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


.love-wrap {
  width: 90%;
  backdrop-filter: blur(10px);
  background: rgba(255, 255, 255, 0.1);
  max-width: 950px;
  border-radius: 3em;
  display: flex;
  align-items: center;
  justify-content: space-around;
  padding: 50px 70px 30px 70px;
}

.love-avatar {
  border: rgba(255, 255, 255, 0.2) 4px solid;
  width: 180px;
  height: 180px;
}

.love-title {
  margin-top: 15px;
  text-align: center;
  font-size: 25px;
  font-weight: 700;
  color: var(--white);
}


.love-img {
  animation: imgScale 2s linear infinite;
  width: 120px;
  height: 120px;
}

#bannerWave1 {
  height: 84px;
  background: var(--bannerWave1);
  position: absolute;
  width: 200%;
  bottom: 0;
  z-index: 10;
  animation: gradientBG 120s linear infinite;
}

#bannerWave2 {
  height: 100px;
  background: var(--bannerWave2);
  position: absolute;
  width: 400%;
  bottom: 0;
  z-index: 5;
  animation: gradientBG 120s linear infinite;
}


.love-content {
  max-width: 1200px;
  overflow: hidden;
  margin: 20px auto 0;
  user-select: none;
  position: absolute;
  left: 50%;
  top: 50%;
  transform: translate(-50%, -60%);
}

.padfix{

  position:relative;
  top: 500px;
}

.card-container {
    max-width: 1500px;
    margin: 20px auto 40px;

  }

.love-time-title1 {
  font-size: 2rem;
  font-weight: 600;
  letter-spacing: 0.2rem;
  line-height: 4rem;
  text-align: center;
  background-image: linear-gradient(100deg, #ff4500, #ffa500, #ffd700, #90ee90, #00ffff, #1e90ff, #9370db, #ff69b4, #ff4500);
  -webkit-background-clip: text;
  color: transparent;
  /* 将文本颜色设置为透明 */
  background-size: 400%;
  animation: jianBian 20s linear infinite alternate;
  /* 应用渐变动画效果 */
}


.love-time-title2 {
  text-align: center;
  font-size: 1.5rem;
  line-height: 4rem;
  font-weight: 600;
  letter-spacing: 2px;
}

.love-time1 {
  text-align: center;
  font-size: 2rem;
  font-weight: 700;

  font-family: Inter, Avenir, Helvetica, Arial, sans-serif;
}

.love-time1-item {
  font-size: 4rem;
  font-weight: 700;
  font-family: Inter, Avenir, Helvetica, Arial, sans-serif;
}


.card-wrap {
    max-width: 1200px;
    margin: 0 auto;
    display: flex;
    justify-content: center;
    padding: 20px 0;
  }

  .card-content {
    display: flex;
    padding: 25px;
    margin: 25px auto;
    border-radius: 20px;
    max-width: 780px;
    cursor: pointer;
    transition: all 0.3s;
    background: var(--background);
  }

  .card-content:hover,
  .family-button:hover,
  .family-wrap:hover {
    transform: translateY(-6px);
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
</style>
