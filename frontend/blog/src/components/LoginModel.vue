<template>
    <v-dialog
        :model-value="isShow"
        @update:model-value="handlerUpdateValue"
        max-width="480px"
        width="480px"
        :fullscreen="isMobile"
        scroll-strategy="block"
        persistent
        class="login-dialog"
        style="z-index: 2000;"
    >
        <!-- 调试信息 -->
        <div v-if="isShow" style="position: fixed; top: 50%; left: 50%; transform: translate(-50%, -50%); background: red; color: white; padding: 20px; z-index: 9999; font-size: 16px;">
            Dialog is open: {{ isShow }}, hidesign: {{ vm.hidesign }}
        </div>

        <!-- 测试卡片 -->
        <div v-if="isShow" style="position: fixed; top: 60%; left: 50%; transform: translate(-50%, -50%); background: blue; color: white; padding: 20px; z-index: 9998;">
            Test Card - This should be visible
        </div>

        <v-card
            class="pa-6"
            v-if="vm.hidesign"
            style="background: white !important; border-radius: 16px !important; box-shadow: 0 4px 20px rgba(0,0,0,0.15) !important; position: relative; z-index: 2001;">
            <div class="login-header">
                <div class="login-avatar">
                    <v-icon size="48" color="white">mdi-account-circle</v-icon>
                </div>
                <h2 class="login-title">欢迎回来</h2>
                <p class="login-subtitle">请登录您的账号</p>
            </div>

            <div class="login-content">
                <v-form @submit.prevent="Login" ref="loginForm" class="login-form">
                    <div class="input-group">
                        <v-text-field
                            v-model="state.ruleForm.account"
                            label="邮箱地址"
                            placeholder="请输入邮箱地址"
                            type="email"
                            :rules="[(v: string) => !!v || '请输入邮箱地址', (v: string) => /.+@.+\..+/.test(v) || '请输入有效的邮箱地址']"
                            variant="outlined"
                            class="modern-input"
                            prepend-inner-icon="mdi-email-outline"
                            color="primary"
                        ></v-text-field>
                    </div>

                    <div class="input-group">
                        <v-text-field
                            v-model="state.ruleForm.password"
                            :append-inner-icon="vm.visible ? 'mdi-eye-off' : 'mdi-eye'"
                            :type="vm.visible ? 'text' : 'password'"
                            label="密码"
                            placeholder="请输入密码"
                            @click:append-inner="vm.visible = !vm.visible"
                            :rules="[(v: string) => !!v || '请输入密码', (v: string) => v.length >= 6 || '密码长度至少为6位']"
                            variant="outlined"
                            class="modern-input"
                            prepend-inner-icon="mdi-lock-outline"
                            color="primary"
                        ></v-text-field>
                    </div>

                    <div class="input-group captcha-group">
                        <v-text-field
                            v-model="state.ruleForm.code"
                            label="验证码"
                            placeholder="请输入验证码"
                            :rules="[(v: string) => !!v || '请输入验证码']"
                            variant="outlined"
                            class="modern-input captcha-input"
                            prepend-inner-icon="mdi-shield-outline"
                            color="primary"
                        ></v-text-field>
                        <v-btn
                            class="captcha-btn"
                            height="56"
                            @click="onCaptchaChange"
                            variant="outlined"
                        >
                            <img :src="captchaUrl" alt="验证码" class="captcha-img" />
                        </v-btn>
                    </div>

                    <div class="login-options">
                        <v-checkbox
                            v-model="state.ruleForm.remember"
                            label="记住密码"
                            hide-details
                            color="primary"
                            class="remember-checkbox"
                        ></v-checkbox>
                        <a class="forgot-link" href="#" @click.prevent="forgotPassword">
                            忘记密码？
                        </a>
                    </div>

                    <v-btn
                        type="submit"
                        color="primary"
                        size="large"
                        block
                        :loading="state.loading.signIn"
                        class="login-btn"
                        elevation="0"
                    >
                        <v-icon left>mdi-login</v-icon>
                        登录
                    </v-btn>

                    <div class="switch-form">
                        <span class="switch-text">还没有账号？</span>
                        <a class="switch-link" href="#" @click.prevent="vm.hidesign = !vm.hidesign">
                            立即注册
                        </a>
                    </div>
                </v-form>
            </div>
        </v-card>

        <v-card class="login-card" v-else>
            <div class="login-header">
                <div class="login-avatar">
                    <v-icon size="48" color="white">mdi-account-plus</v-icon>
                </div>
                <h2 class="login-title">创建账号</h2>
                <p class="login-subtitle">请填写以下信息完成注册</p>
            </div>

            <div class="login-content">
                <v-form @submit.prevent="GetSign" ref="signupForm" class="login-form">
                    <div class="input-group">
                        <v-text-field
                            v-model="vm.email"
                            label="邮箱地址"
                            placeholder="请输入邮箱地址"
                            type="email"
                            :rules="[(v: string) => !!v || '请输入邮箱地址', (v: string) => /.+@.+\..+/.test(v) || '请输入有效的邮箱地址']"
                            variant="outlined"
                            class="modern-input"
                            prepend-inner-icon="mdi-email-outline"
                            color="primary"
                        ></v-text-field>
                    </div>

                    <div class="input-group">
                        <v-text-field
                            v-model="vm.password"
                            :append-inner-icon="vm.visible ? 'mdi-eye-off' : 'mdi-eye'"
                            :type="vm.visible ? 'text' : 'password'"
                            label="密码"
                            placeholder="请输入密码"
                            @click:append-inner="vm.visible = !vm.visible"
                            :rules="[(v: string) => !!v || '请输入密码', (v: string) => v.length >= 6 || '密码长度至少为6位']"
                            variant="outlined"
                            class="modern-input"
                            prepend-inner-icon="mdi-lock-outline"
                            color="primary"
                        ></v-text-field>
                    </div>

                    <div class="input-group" v-if="vm.codeinput">
                        <v-text-field
                            v-model="vm.code"
                            label="验证码"
                            placeholder="请输入邮箱验证码"
                            :rules="[(v: string) => !!v || '请输入验证码']"
                            variant="outlined"
                            class="modern-input"
                            prepend-inner-icon="mdi-shield-outline"
                            color="primary"
                        ></v-text-field>
                    </div>

                    <v-btn
                        type="submit"
                        color="primary"
                        size="large"
                        block
                        :loading="state.loading.signUp"
                        class="login-btn"
                        elevation="0"
                    >
                        <v-icon left>{{ vm.codeinput ? 'mdi-check' : 'mdi-email-send' }}</v-icon>
                        {{ vm.codeinput ? '完成注册' : '获取验证码' }}
                    </v-btn>

                    <div class="switch-form">
                        <span class="switch-text">已有账号？</span>
                        <a class="switch-link" href="#" @click.prevent="vm.hidesign = !vm.hidesign">
                            立即登录
                        </a>
                    </div>
                </v-form>
            </div>
        </v-card>
    </v-dialog>
</template>

<script setup lang="ts">
import { computed, ref, watch, watchEffect, reactive } from "vue";
import { useRouter } from "vue-router";
import dayjs from 'dayjs';
import { ArticleOutput } from "@/api/models";
import OAuthApi from "@/api/OAuthApi";
import { useToast } from "@/stores/toast";

const props = defineProps<{
    isShow: boolean;
}>();

const toast = useToast();
const router = useRouter();
const loginForm = ref<any>(null);
const signupForm = ref<any>(null);

const vm = reactive({
    visible: false,
    hidesign: true,
    codeinput: false,
    password: "",
    email: "",
    code: "",
});

const state = reactive({
    isShowPassword: false,
    random: new Date().getTime(),
    ruleForm: {
        account: '',
        password: '',
        code: '',
        id: dayjs().valueOf().toString(),
        referer: '',
        remember: false,
    },
    loading: {
        signIn: false,
        signUp: false,
    },
});

const onCaptchaChange = () => {
    state.random = new Date().getTime();
};

const captchaUrl = computed(() => {
    return `http://140.246.62.164:8088/api/auth/captcha?id=${state.ruleForm.id}&r=${state.random}`;
});

const emit = defineEmits<{ (e: "update:isShow", isShow: boolean): void }>();

const forgotPassword = () => {
    // 实现忘记密码功能
    toast.info("忘记密码功能开发中");
};

const GetSign = async () => {
    const isValid = await signupForm.value?.validate();
    if (!isValid) return;

    state.loading.signUp = true;
    try {
        if (vm.code === "") {
            const { statusCode, succeeded } = await OAuthApi.SendEmail(vm.email);
            if (statusCode === 200) {
                vm.codeinput = true;
                toast.success("验证码已发送至邮箱，请查收");
            }
        } else {
            const { statusCode } = await OAuthApi.Register({
                email: vm.email,
                code: vm.code,
                password: vm.password
            });
            if (statusCode === 200) {
                toast.success("注册成功！");
                vm.hidesign = true;
                // 重置表单
                vm.email = "";
                vm.password = "";
                vm.code = "";
                vm.codeinput = false;
            }
        }
    } catch (error) {
        toast.error("操作失败，请重试");
    } finally {
        state.loading.signUp = false;
    }
};

const Login = async () => {
    const isValid = await loginForm.value?.validate();
    if (!isValid) return;

    state.loading.signIn = true;
    try {
        state.ruleForm.referer = location.href;
        const response = await OAuthApi.loginemail(state.ruleForm);
        if (response.statusCode === 200) {
            window.location.href = response.data;
        }else{
            onCaptchaChange();

        }
    } catch (error) {
        toast.error("登录失败，请检查账号密码");
    } finally {
        state.loading.signIn = false;
    }
};

const handlerUpdateValue = (v: boolean) => {
    emit("update:isShow", v);
};

const isMobile = computed(() => {
    const clientWidth = document.documentElement.clientWidth;
    return clientWidth <= 960;
});

watch(isMobile, () => {
    emit("update:isShow", false);
});
</script>

<style scoped>
/* 登录对话框背景 */
.login-dialog :deep(.v-overlay__scrim) {
    background: rgba(0, 0, 0, 0.6) !important;
    backdrop-filter: blur(8px);
    -webkit-backdrop-filter: blur(8px);
}

.login-dialog {
    position: relative;
}

/* 登录卡片 - 毛玻璃效果 */
.login-card {
    background: white !important;
    border-radius: 16px !important;
    box-shadow: 0 8px 32px rgba(0, 0, 0, 0.12) !important;
    border: 1px solid rgba(0, 0, 0, 0.1) !important;
    max-width: 480px;
    width: 100%;
    margin: 20px;
}



/* 登录头部 */
.login-header {
    text-align: center;
    padding: 30px 20px 20px;
    background: #f8f9fa;
    border-radius: 16px 16px 0 0;
}

.login-avatar {
    margin-bottom: 16px;
    display: inline-flex;
    align-items: center;
    justify-content: center;
    width: 80px;
    height: 80px;
    background: linear-gradient(135deg, #49b1f5, #00c4b6);
    border-radius: 50%;
    box-shadow: 0 8px 24px rgba(73, 177, 245, 0.3);
}

.login-title {
    font-size: 28px;
    font-weight: 700;
    color: #2c3e50;
    margin: 0 0 8px 0;
    background: linear-gradient(135deg, #49b1f5, #00c4b6);
    -webkit-background-clip: text;
    -webkit-text-fill-color: transparent;
    background-clip: text;
}

.login-subtitle {
    font-size: 16px;
    color: #7f8c8d;
    margin: 0;
    font-weight: 400;
}

/* 登录内容区域 */
.login-content {
    padding: 20px 30px 30px;
}

.login-form {
    width: 100%;
}

/* 输入框组 */
.input-group {
    margin-bottom: 24px;
    position: relative;
}

.modern-input {
    transition: all 0.3s ease;
}

.modern-input :deep(.v-field) {
    background: rgba(255, 255, 255, 0.7) !important;
    backdrop-filter: blur(15px);
    -webkit-backdrop-filter: blur(15px);
    border-radius: 16px !important;
    border: 1px solid rgba(73, 177, 245, 0.3) !important;
    box-shadow: 0 4px 15px rgba(0, 0, 0, 0.08),
                inset 0 1px 0 rgba(255, 255, 255, 0.5);
    transition: all 0.3s ease;
}

.modern-input :deep(.v-field:hover) {
    border-color: rgba(73, 177, 245, 0.4) !important;
    box-shadow: 0 6px 20px rgba(73, 177, 245, 0.1);
    transform: translateY(-1px);
}

.modern-input :deep(.v-field--focused) {
    border-color: #49b1f5 !important;
    box-shadow: 0 8px 24px rgba(73, 177, 245, 0.2);
    transform: translateY(-2px);
}

.modern-input :deep(.v-field__input) {
    padding: 16px 20px;
    font-size: 16px;
    color: #2c3e50;
}

.modern-input :deep(.v-field__prepend-inner) {
    padding-left: 16px;
    color: #49b1f5;
}

.modern-input :deep(.v-field__append-inner) {
    padding-right: 16px;
    color: #7f8c8d;
}

/* 验证码组 */
.captcha-group {
    display: flex;
    gap: 12px;
    align-items: flex-start;
}

.captcha-input {
    flex: 1;
}

.captcha-btn {
    background: rgba(255, 255, 255, 0.7) !important;
    backdrop-filter: blur(15px);
    -webkit-backdrop-filter: blur(15px);
    border: 1px solid rgba(73, 177, 245, 0.3) !important;
    border-radius: 16px !important;
    min-width: 100px;
    box-shadow: 0 4px 15px rgba(0, 0, 0, 0.08),
                inset 0 1px 0 rgba(255, 255, 255, 0.5);
    transition: all 0.3s ease;
}

.captcha-btn:hover {
    border-color: rgba(73, 177, 245, 0.4) !important;
    transform: translateY(-1px);
    box-shadow: 0 6px 20px rgba(73, 177, 245, 0.1);
}

.captcha-img {
    height: 40px;
    border-radius: 8px;
}

/* 登录选项 */
.login-options {
    display: flex;
    justify-content: space-between;
    align-items: center;
    margin-bottom: 32px;
}

.remember-checkbox :deep(.v-selection-control__wrapper) {
    color: #49b1f5;
}

.forgot-link {
    color: #49b1f5;
    text-decoration: none;
    font-size: 14px;
    font-weight: 500;
    transition: all 0.3s ease;
}

.forgot-link:hover {
    color: #00c4b6;
    text-decoration: underline;
}

/* 登录按钮 */
.login-btn {
    background: linear-gradient(135deg, #49b1f5, #00c4b6) !important;
    border-radius: 16px !important;
    height: 56px !important;
    font-size: 16px !important;
    font-weight: 600 !important;
    text-transform: none !important;
    letter-spacing: 0.5px;
    margin-bottom: 24px;
    position: relative;
    overflow: hidden;
    transition: all 0.3s ease;
}

.login-btn::before {
    content: '';
    position: absolute;
    top: 0;
    left: -100%;
    width: 100%;
    height: 100%;
    background: linear-gradient(90deg, transparent, rgba(255, 255, 255, 0.2), transparent);
    transition: left 0.5s ease;
}

.login-btn:hover::before {
    left: 100%;
}

.login-btn:hover {
    transform: translateY(-2px);
    box-shadow: 0 12px 32px rgba(73, 177, 245, 0.3);
}

.login-btn:active {
    transform: translateY(0);
}

/* 切换表单 */
.switch-form {
    text-align: center;
    padding-top: 16px;
    border-top: 1px solid rgba(0, 0, 0, 0.1);
}

.switch-text {
    color: #7f8c8d;
    font-size: 14px;
}

.switch-link {
    color: #49b1f5;
    text-decoration: none;
    font-weight: 600;
    margin-left: 8px;
    transition: all 0.3s ease;
}

.switch-link:hover {
    color: #00c4b6;
    text-decoration: underline;
}

/* 动画效果 */
@keyframes slideUp {
    from {
        opacity: 0;
        transform: translateY(30px) scale(0.95);
    }
    to {
        opacity: 1;
        transform: translateY(0) scale(1);
    }
}

/* 响应式设计 */
@media (max-width: 600px) {
    .login-header {
        padding: 30px 24px 16px;
    }

    .login-content {
        padding: 16px 24px 30px;
    }

    .login-title {
        font-size: 24px;
    }

    .login-subtitle {
        font-size: 14px;
    }

    .captcha-group {
        flex-direction: column;
        gap: 16px;
    }

    .captcha-btn {
        width: 100%;
    }

    .login-options {
        flex-direction: column;
        gap: 16px;
        align-items: flex-start;
    }
}

/* 深色模式适配 */
@media (prefers-color-scheme: dark) {
    .login-card {
        background: rgba(30, 30, 30, 0.95) !important;
        border: 1px solid rgba(255, 255, 255, 0.1);
    }

    .login-title {
        color: #ffffff;
    }

    .login-subtitle {
        color: #b0b0b0;
    }

    .modern-input :deep(.v-field) {
        background: rgba(40, 40, 40, 0.8) !important;
        border: 1px solid rgba(73, 177, 245, 0.3) !important;
    }

    .modern-input :deep(.v-field__input) {
        color: #ffffff;
    }

    .captcha-btn {
        background: rgba(40, 40, 40, 0.8) !important;
        border: 1px solid rgba(73, 177, 245, 0.3) !important;
    }

    .switch-text {
        color: #b0b0b0;
    }
}
</style>