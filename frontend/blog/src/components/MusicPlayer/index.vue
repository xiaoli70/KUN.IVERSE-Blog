<template>
  <div class="music-player" :class="{ 'mini-mode': isMiniMode }">
    <div class="player-content">
      <div class="song-info">
        <img :src="currentSong.cover || '/default-cover.jpg'" alt="封面" class="cover-img" />
        <div class="song-details">
          <div class="song-name">{{ currentSong.name || '未播放' }}</div>
          <div class="artist">{{ currentSong.artist || '未知歌手' }}</div>
        </div>
      </div>
      
      <div class="controls">
        <div class="progress-bar" @click="handleProgressClick">
          <div class="progress" :style="{ width: progress + '%' }"></div>
        </div>
        
        <div class="control-buttons">
          <button @click="prevSong" title="上一首">
            <i class="fas fa-step-backward"></i>
          </button>
          <button @click="togglePlay" class="play-btn" title="播放/暂停">
            <i :class="isPlaying ? 'fas fa-pause' : 'fas fa-play'"></i>
          </button>
          <button @click="nextSong" title="下一首">
            <i class="fas fa-step-forward"></i>
          </button>
          <div class="volume-control">
            <i :class="isMuted ? 'fas fa-volume-mute' : 'fas fa-volume-up'" @click="toggleMute"></i>
            <input type="range" v-model="volume" min="0" max="100" @input="handleVolumeChange" />
          </div>
        </div>
      </div>
    </div>
    
    <button class="mini-toggle" @click="toggleMiniMode" :title="isMiniMode ? '展开' : '收起'">
      <i :class="isMiniMode ? 'fas fa-expand' : 'fas fa-compress'"></i>
    </button>
  </div>
</template>

<script setup lang="ts">
import { ref, reactive, onMounted } from 'vue'
import { playlist } from '@/assets/music/playlist'

// 播放状态
const isPlaying = ref(false)
const isMiniMode = ref(false)
const isMuted = ref(false)
const volume = ref(100)
const progress = ref(0)
const currentIndex = ref(0)
const audio = ref<HTMLAudioElement | null>(null)

// 当前歌曲信息
const currentSong = reactive({
  name: '',
  artist: '',
  cover: '',
  url: ''
})

// 初始化音频播放器
onMounted(() => {
  audio.value = new Audio()
  audio.value.addEventListener('timeupdate', updateProgress)
  audio.value.addEventListener('ended', () => nextSong())
  loadSong(currentIndex.value)
})

// 加载歌曲
const loadSong = (index: number) => {
  const song = playlist[index]
  currentSong.name = song.name
  currentSong.artist = song.artist
  currentSong.cover = song.cover
  currentSong.url = song.url
  
  if (audio.value) {
    audio.value.src = song.url
    if (isPlaying.value) {
      audio.value.play()
    }
  }
}

// 更新进度条
const updateProgress = () => {
  if (audio.value) {
    const { currentTime, duration } = audio.value
    progress.value = (currentTime / duration) * 100
  }
}

// 播放控制方法
const togglePlay = () => {
  if (!audio.value) return
  
  isPlaying.value = !isPlaying.value
  if (isPlaying.value) {
    audio.value.play()
  } else {
    audio.value.pause()
  }
}

const prevSong = () => {
  currentIndex.value = currentIndex.value > 0 ? currentIndex.value - 1 : playlist.length - 1
  loadSong(currentIndex.value)
}

const nextSong = () => {
  currentIndex.value = currentIndex.value < playlist.length - 1 ? currentIndex.value + 1 : 0
  loadSong(currentIndex.value)
}

const toggleMute = () => {
  if (!audio.value) return
  
  isMuted.value = !isMuted.value
  audio.value.muted = isMuted.value
}

const handleVolumeChange = () => {
  if (!audio.value) return
  
  audio.value.volume = volume.value / 100
}

const handleProgressClick = (event: MouseEvent) => {
  if (!audio.value) return
  
  const progressBar = event.currentTarget as HTMLElement
  const rect = progressBar.getBoundingClientRect()
  const percent = (event.clientX - rect.left) / rect.width
  audio.value.currentTime = percent * audio.value.duration
}

const toggleMiniMode = () => {
  isMiniMode.value = !isMiniMode.value
}
</script>

<style scoped>
.music-player {
  position: fixed;
  right: 20px;
  bottom: 20px;
  width: 300px;
  background: rgba(255, 255, 255, 0.9);
  backdrop-filter: blur(10px);
  border-radius: 12px;
  box-shadow: 0 4px 12px rgba(0, 0, 0, 0.1);
  padding: 15px;
  transition: all 0.3s ease;
  z-index: 1000;
}

.player-content {
  display: flex;
  flex-direction: column;
  gap: 15px;
}

.song-info {
  display: flex;
  align-items: center;
  gap: 12px;
}

.cover-img {
  width: 60px;
  height: 60px;
  border-radius: 8px;
  object-fit: cover;
}

.song-details {
  flex: 1;
  min-width: 0;
}

.song-name {
  font-weight: bold;
  margin-bottom: 4px;
  white-space: nowrap;
  overflow: hidden;
  text-overflow: ellipsis;
}

.artist {
  font-size: 0.9em;
  color: #666;
  white-space: nowrap;
  overflow: hidden;
  text-overflow: ellipsis;
}

.controls {
  display: flex;
  flex-direction: column;
  gap: 10px;
}

.progress-bar {
  width: 100%;
  height: 4px;
  background: #e0e0e0;
  border-radius: 2px;
  cursor: pointer;
  position: relative;
}

.progress {
  position: absolute;
  height: 100%;
  background: #1890ff;
  border-radius: 2px;
}

.control-buttons {
  display: flex;
  align-items: center;
  justify-content: space-between;
  gap: 10px;
}

.control-buttons button {
  background: none;
  border: none;
  cursor: pointer;
  padding: 8px;
  border-radius: 50%;
  transition: background-color 0.2s;
}

.control-buttons button:hover {
  background: rgba(0, 0, 0, 0.05);
}

.play-btn {
  width: 40px;
  height: 40px;
  display: flex;
  align-items: center;
  justify-content: center;

}

.volume-control {
  display: flex;
  align-items: center;
  gap: 8px;
}

.volume-control input[type="range"] {
  width: 80px;
}

.mini-toggle {
  position: absolute;
  top: 10px;
  right: 10px;
  background: none;
  border: none;
  cursor: pointer;
  padding: 4px;
  border-radius: 4px;
  transition: background-color 0.2s;
}

.mini-toggle:hover {
  background: rgba(0, 0, 0, 0.05);
}

/* 迷你模式样式 */
.mini-mode {
  width: 60px;
  height: 60px;
  padding: 8px;
  overflow: hidden;
}

.mini-mode .player-content {
  opacity: 0;
}

.mini-mode .mini-toggle {
  top: 50%;
  right: 50%;
  transform: translate(50%, -50%);
}

@media (max-width: 768px) {
  .music-player {
    width: calc(100% - 40px);
    max-width: 300px;
  }
}
</style>