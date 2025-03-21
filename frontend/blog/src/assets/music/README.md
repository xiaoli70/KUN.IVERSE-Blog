# 音乐资源目录

此目录用于存放音乐播放器所需的资源文件：

## 目录结构

```
music/
├── covers/        # 歌曲封面图片
├── songs/         # 音频文件（支持的格式：MP3）
└── playlist.ts    # 播放列表配置文件
```

## 添加新歌曲

1. 将音频文件（.mp3）放入 `songs` 目录
2. 将封面图片放入 `covers` 目录
3. 在 `playlist.ts` 中添加歌曲信息：

```typescript
{
  id: number,      // 唯一标识
  name: string,    // 歌曲名称
  artist: string,  // 艺术家
  cover: string,   // 封面图片路径
  url: string      // 音频文件路径
}
```

注意：所有资源文件路径都应该使用相对于 `src` 目录的路径，例如：
- 封面图片：`/src/assets/music/covers/example.jpg`
- 音频文件：`/src/assets/music/songs/example.mp3`