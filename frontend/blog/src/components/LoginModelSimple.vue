<template>
    <v-dialog
        :model-value="isShow"
        @update:model-value="handlerUpdateValue"
        max-width="400"
    >
        <v-card class="pa-0 login-card">
            <div class="login-header">
                <v-avatar size="80" color="primary" class="mb-4">
                    <v-icon size="40" color="white">{{ vm.hidesign ? 'mdi-account-circle' : 'mdi-account-plus' }}</v-icon>
                </v-avatar>
                <h3 class="login-title">{{ vm.hidesign ? '欢迎回来' : '创建账号' }}</h3>
                <p class="login-subtitle">{{ vm.hidesign ? '请登录您的账号' : '请填写以下信息完成注册' }}</p>
            </div>

            <div class="login-content" v-if="vm.hidesign">
                <v-form @submit.prevent="Login" ref="loginForm">
                    <v-text-field
                        v-model="state.ruleForm.account"
                        label="邮箱地址"
                        placeholder="请输入邮箱地址"
                        type="email"
                        :rules="[(v: string) => !!v || '请输入邮箱地址', (v: string) => /.+@.+\..+/.test(v) || '请输入有效的邮箱地址']"
                        variant="outlined"
                        class="mb-3"
                        prepend-inner-icon="mdi-email-outline"
                    ></v-text-field>

                    <v-text-field
                        v-model="state.ruleForm.password"
                        :append-inner-icon="vm.visible ? 'mdi-eye-off' : 'mdi-eye'"
                        :type="vm.visible ? 'text' : 'password'"
                        label="密码"
                        placeholder="请输入密码"
                        @click:append-inner="vm.visible = !vm.visible"
                        :rules="[(v: string) => !!v || '请输入密码', (v: string) => v.length >= 6 || '密码长度至少为6位']"
                        variant="outlined"
                        class="mb-3"
                        prepend-inner-icon="mdi-lock-outline"
                    ></v-text-field>

                    <div class="d-flex mb-3">
                        <v-text-field
                            v-model="state.ruleForm.code"
                            label="验证码"
                            placeholder="请输入验证码"
                            :rules="[(v: string) => !!v || '请输入验证码']"
                            variant="outlined"
                            class="me-2"
                            prepend-inner-icon="mdi-shield-outline"
                        ></v-text-field>
                        <v-btn 
                            height="56" 
                            @click="onCaptchaChange"
                            variant="outlined"
                        >
                            <img :src="captchaUrl" alt="验证码" style="height: 40px;" />
                        </v-btn>
                    </div>

                    <v-btn
                        type="submit"
                        color="primary"
                        size="large"
                        block
                        :loading="state.loading.signIn"
                        class="mb-3"
                    >
                        登录
                    </v-btn>

                    <div class="d-flex justify-space-between align-center mb-3">
                        <v-checkbox
                            v-model="state.ruleForm.remember"
                            label="记住密码"
                            hide-details
                            color="primary"
                        ></v-checkbox>
                        <a href="#" @click.prevent="forgotPassword" class="text-primary">
                            忘记密码？
                        </a>
                    </div>

                    <div class="text-center">
                        <span>还没有账号？</span>
                        <a href="#" @click.prevent="vm.hidesign = !vm.hidesign" class="text-primary">
                            立即注册
                        </a>
                    </div>
                </v-form>
            </div>

            <div class="login-content" v-else>
                <v-form @submit.prevent="GetSign" ref="signupForm">
                    <v-text-field
                        v-model="vm.email"
                        label="邮箱地址"
                        placeholder="请输入邮箱地址"
                        type="email"
                        :rules="[(v: string) => !!v || '请输入邮箱地址', (v: string) => /.+@.+\..+/.test(v) || '请输入有效的邮箱地址']"
                        variant="outlined"
                        class="mb-3"
                        prepend-inner-icon="mdi-email-outline"
                    ></v-text-field>

                    <v-text-field
                        v-model="vm.password"
                        :append-inner-icon="vm.visible ? 'mdi-eye-off' : 'mdi-eye'"
                        :type="vm.visible ? 'text' : 'password'"
                        label="密码"
                        placeholder="请输入密码"
                        @click:append-inner="vm.visible = !vm.visible"
                        :rules="[(v: string) => !!v || '请输入密码', (v: string) => v.length >= 6 || '密码长度至少为6位']"
                        variant="outlined"
                        class="mb-3"
                        prepend-inner-icon="mdi-lock-outline"
                    ></v-text-field>

                    <v-text-field
                        v-if="vm.codeinput"
                        v-model="vm.code"
                        label="验证码"
                        placeholder="请输入邮箱验证码"
                        :rules="[(v: string) => !!v || '请输入验证码']"
                        variant="outlined"
                        class="mb-3"
                        prepend-inner-icon="mdi-shield-outline"
                    ></v-text-field>

                    <v-btn
                        type="submit"
                        color="primary"
                        size="large"
                        block
                        :loading="state.loading.signUp"
                        class="mb-3"
                    >
                        {{ vm.codeinput ? '完成注册' : '获取验证码' }}
                    </v-btn>

                    <div class="text-center">
                        <span>已有账号？</span>
                        <a href="#" @click.prevent="vm.hidesign = !vm.hidesign" class="text-primary">
                            立即登录
                        </a>
                    </div>
                </v-form>
            </div>
        </v-card>
    </v-dialog>
</template>

<script setup lang="ts">
import { computed, ref, reactive } from "vue";
import dayjs from 'dayjs';
import OAuthApi from "@/api/OAuthApi";
import { useToast } from "@/stores/toast";

const props = defineProps<{
    isShow: boolean;
}>();

const toast = useToast();
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
        } else {
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
    return clientWidth < 768;
});
</script>

<style scoped>
/* 登录卡片 - 毛玻璃效果 */
.login-card {
    background: rgba(255, 255, 255, 0.95) !important;
    backdrop-filter: blur(15px);
    -webkit-backdrop-filter: blur(15px);
    border: 1px solid rgba(255, 255, 255, 0.2);
    border-radius: 20px !important;
    box-shadow: 0 20px 40px rgba(0, 0, 0, 0.1),
                0 8px 32px rgba(0, 0, 0, 0.08);
    position: relative;
    overflow: hidden;
}

/* 登录头部 */
.login-header {
    text-align: center;
    padding: 30px 30px 20px;
    background: linear-gradient(135deg, rgba(73, 177, 245, 0.05), rgba(0, 196, 182, 0.05));
    border-radius: 20px 20px 0 0;
}

.login-title {
    background: linear-gradient(135deg, #49b1f5, #00c4b6);
    -webkit-background-clip: text;
    -webkit-text-fill-color: transparent;
    background-clip: text;
    font-weight: 700;
    font-size: 24px;
    margin: 0 0 8px 0;
}

.login-subtitle {
    color: #7f8c8d;
    font-size: 14px;
    margin: 0;
}

/* 登录内容区域 */
.login-content {
    padding: 20px 30px 30px;
}

/* 输入框样式 */
.login-card :deep(.v-field) {
    background: rgba(255, 255, 255, 0.8) !important;
    backdrop-filter: blur(10px);
    -webkit-backdrop-filter: blur(10px);
    border-radius: 12px !important;
    border: 1px solid rgba(73, 177, 245, 0.2) !important;
    box-shadow: 0 2px 8px rgba(0, 0, 0, 0.05);
    transition: all 0.3s ease;
}

.login-card :deep(.v-field:hover) {
    border-color: rgba(73, 177, 245, 0.4) !important;
    box-shadow: 0 4px 12px rgba(73, 177, 245, 0.1);
    transform: translateY(-1px);
}

.login-card :deep(.v-field--focused) {
    border-color: #49b1f5 !important;
    box-shadow: 0 6px 20px rgba(73, 177, 245, 0.2);
    transform: translateY(-2px);
}

/* 按钮样式 */
.login-card :deep(.v-btn--variant-elevated) {
    background: linear-gradient(135deg, #49b1f5, #00c4b6) !important;
    border-radius: 12px !important;
    font-weight: 600 !important;
    text-transform: none !important;
    letter-spacing: 0.5px;
    transition: all 0.3s ease;
}

.login-card :deep(.v-btn--variant-elevated:hover) {
    transform: translateY(-2px);
    box-shadow: 0 8px 25px rgba(73, 177, 245, 0.3);
}

/* 标题样式 */
.login-card :deep(.v-card-title h3) {
    background: linear-gradient(135deg, #49b1f5, #00c4b6);
    -webkit-background-clip: text;
    -webkit-text-fill-color: transparent;
    background-clip: text;
    font-weight: 700;
    font-size: 24px;
}

/* 链接样式 */
.login-card a {
    color: #49b1f5;
    text-decoration: none;
    font-weight: 500;
    transition: all 0.3s ease;
}

.login-card a:hover {
    color: #00c4b6;
    text-decoration: underline;
}

/* 对话框背景 */
:deep(.v-overlay__scrim) {
    background: rgba(0, 0, 0, 0.6) !important;
    backdrop-filter: blur(8px);
    -webkit-backdrop-filter: blur(8px);
}

/* 响应式设计 */
@media (max-width: 600px) {
    .login-card {
        margin: 16px;
        border-radius: 16px !important;
    }
}
</style>
