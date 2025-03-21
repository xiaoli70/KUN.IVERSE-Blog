interface Song {
  id: number;
  name: string;
  artist: string;
  cover: string;
  url: string;
}

export const playlist: Song[] = [
  {
    id: 1,
    name: '海阔天空',
    artist: 'Beyond',
    cover: 'http://111.173.104.127:8081/oss/2024/03/04/ANba4d0Mpm.jpg',
    url: 'http://111.173.104.127:8081/oss/music/songs/海阔天空.mp3'
  }
  
];