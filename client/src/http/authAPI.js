import { $authhost, $host } from "./index.js";

export const defaultLogin = async (obj) => {
    const { data } = await $host.post('api/auth/login', obj)
    return data;
}

export const check = async () => {
    const { data } = await $authhost.post('api/auth/checkSignIn');
    return data;
}

export const registAdmin = async(form) => {
    const { data } = await $host.post('api/auth/reg/admin', form);
    return data;
}

export const registWorker = async(form) => {
    const { data } = await $host.post('api/auth/reg/worker', form);
    return data;
}

export const banAccount = async (id) => {
    const { data } = await $host.post(`api/auth/setBan/${id}`);
    return data;
}