import { $authhost, $host } from "./index.js";

export const getTypes = async (name = "") => {
    const { data } = await $host.get(`api/gasType?name=${name}`)
    return data;
}

export const getType = async (typeId) => {
    const { data } = await $host.get('api/gasType/' + typeId)
    return data;
}

export const createType = async (form) => {
    const { data } = await $host.post('api/gasType', form)
    return data;
}

export const updateType = async (form) => {
    const { data } = await $host.put('api/gasType', form)
    return data;
}

export const removeType = async (typeId) => {
    const { data } = await $host.delete('api/gasType/' + typeId)
    return data;
}