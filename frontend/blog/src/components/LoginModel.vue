<template>
    <v-dialog v-bind:model-value="isShow" @update:model-value="handlerUpdateValue" max-width="600"
        :fullscreen="isMobile" scroll-strategy="none">
        <v-card class="search-wrapper elevation-3" style="border-radius: 12px;text-align: center;" v-if="vm.hidesign">
            <v-card-title class="text-center pt-6">
                <h3 class="text-h5 font-weight-bold mb-2">欢迎回来</h3>
                <p class="text-subtitle-1 text-medium-emphasis">请登录您的账号</p>
            </v-card-title>

            <v-card-text class="pa-6">
                <v-form @submit.prevent="Login" ref="loginForm">
                    <v-text-field
                        v-model="state.ruleForm.account"
                        label="邮箱地址"
                        placeholder="请输入邮箱地址"
                        type="email"
                        :rules="[(v: string) => !!v || '请输入邮箱地址', (v: string) => /.+@.+\..+/.test(v) || '请输入有效的邮箱地址']"
                        variant="outlined"
                        class="mb-4"
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
                        class="mb-4"
                        prepend-inner-icon="mdi-lock-outline"
                    ></v-text-field>

                    <div class="d-flex align-center mb-4">
                        <v-text-field
                            v-model="state.ruleForm.code"
                            label="验证码"
                            placeholder="请输入验证码"
                            :rules="[(v: string) => !!v || '请输入验证码']"
                            variant="outlined"
                            class="me-2"
                            prepend-inner-icon="mdi-shield-outline"
                        ></v-text-field>
                        <v-btn class="flex-shrink-0" height="56" @click="onCaptchaChange">
                            <img :src="captchaUrl" alt="验证码" style="height: 40px;" />
                        </v-btn>
                    </div>

                    <div class="d-flex align-center justify-space-between mb-6">
                        <v-checkbox v-model="state.ruleForm.remember" label="记住密码" hide-details></v-checkbox>
                        <a class="text-decoration-none text-blue" href="#" @click.prevent="forgotPassword">
                            忘记密码？
                        </a>
                    </div>

                    <v-btn
                        type="submit"
                        color="primary"
                        size="large"
                        block
                        :loading="state.loading.signIn"
                        class="mb-4"
                    >
                        登录
                    </v-btn>

                    <div class="text-center">
                        <span class="text-medium-emphasis">还没有账号？</span>
                        <a class="text-decoration-none text-primary ms-2" href="#" @click.prevent="vm.hidesign = !vm.hidesign">
                            立即注册
                        </a>
                    </div>
                </v-form>
            </v-card-text>
        </v-card>

        <v-card class="search-wrapper elevation-3" style="border-radius: 12px;text-align: center;" v-else>
            <v-card-title class="text-center pt-6">
                <h3 class="text-h5 font-weight-bold mb-2">创建账号</h3>
                <p class="text-subtitle-1 text-medium-emphasis">请填写以下信息完成注册</p>
            </v-card-title>

            <v-card-text class="pa-6">
                <v-form @submit.prevent="GetSign" ref="signupForm">
                    <v-text-field
                        v-model="vm.email"
                        label="邮箱地址"
                        placeholder="请输入邮箱地址"
                        type="email"
                        :rules="[(v: string) => !!v || '请输入邮箱地址', (v: string) => /.+@.+\..+/.test(v) || '请输入有效的邮箱地址']"
                        variant="outlined"
                        class="mb-4"
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
                        class="mb-4"
                        prepend-inner-icon="mdi-lock-outline"
                    ></v-text-field>

                    <v-text-field
                        v-if="vm.codeinput"
                        v-model="vm.code"
                        label="验证码"
                        placeholder="请输入邮箱验证码"
                        :rules="[(v: string) => !!v || '请输入验证码']"
                        variant="outlined"
                        class="mb-4"
                        prepend-inner-icon="mdi-shield-outline"
                    ></v-text-field>

                    <v-btn
                        type="submit"
                        color="primary"
                        size="large"
                        block
                        :loading="state.loading.signUp"
                        class="mb-4"
                    >
                        {{ vm.codeinput ? '完成注册' : '获取验证码' }}
                    </v-btn>

                    <div class="text-center">
                        <span class="text-medium-emphasis">已有账号？</span>
                        <a class="text-decoration-none text-primary ms-2" href="#" @click.prevent="vm.hidesign = !vm.hidesign">
                            立即登录
                        </a>
                    </div>
                </v-form>
            </v-card-text>
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
    return `http://111.173.104.127:8081/api/auth/captcha?id=${state.ruleForm.id}&r=${state.random}`;
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
.search-wrapper {
    padding: 0;
    height: 100%;
    background-image: linear-gradient(to right, rgba(37, 82, 110, 0.1) 1px, var(--background) 1px), linear-gradient(to bottom, rgba(37, 82, 110, 0.1) 1px, var(--background) 1px);
    transition: all 0.3s ease;
}

.search-wrapper:hover {
    transform: translateY(-2px);
}

@media (min-width: 960px) {
    .search-result-wrapper {
        padding-right: 5px;
        height: 450px;
        overflow: auto;
    }
}

@media (max-width: 959px) {
    .search-result-wrapper {
        height: calc(100vh - 110px);
        overflow: auto;
    }
}
</style>