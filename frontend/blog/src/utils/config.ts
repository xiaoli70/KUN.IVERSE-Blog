// 全局配置文件
export const API_BASE_URL = import.meta.env.VITE_API_URL || "http://140.246.62.164:8088";
export const API_URL = `${API_BASE_URL}/api`;
export const ASSETS_URL = API_BASE_URL;

// 获取封面图完整路径
export const getFullImageUrl = (relativePath: string): string => {
  if (!relativePath) return '';
  
  // 如果路径已经包含完整URL，则直接返回
  if (relativePath.startsWith('http://') || relativePath.startsWith('https://')) {
    return relativePath;
  }
  
  // 确保相对路径以/开头
  const path = relativePath.startsWith('/') ? relativePath : `/${relativePath}`;
  return `${ASSETS_URL}${path}`;
}; 