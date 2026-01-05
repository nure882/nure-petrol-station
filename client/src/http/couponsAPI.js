import { $authhost, $host } from "./index.js";

export const getCoupons = async (name = "", email = "") => {
    const { data } = await $host.get(`api/coupon?name=${name}&email=${email}`)
    return data;
}

export const getCoupon = async (couponId) => {
    const { data } = await $host.get('api/coupon/' + couponId);
    return data;
}

export const createCoupon = async (form) => {
    const { data } = await $host.post('api/coupon', form)
    return data;
}

export const updateCoupon = async (form) => {
    const { data } = await $host.put('api/coupon', form)
    return data;
}

export const removeCoupon = async (couponId) => {
    const { data } = await $host.delete('api/coupon/' + couponId)
    return data;
}