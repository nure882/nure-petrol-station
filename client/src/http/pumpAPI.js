import { $authhost, $host } from "./index.js";

export const getPumps = async (number = 0, gasCountFrom = 0, gasCountTo = 0) => {
    const { data } = await $host.get(`api/pump?number=${number}&gasCountFrom=${gasCountFrom}&gasCountTo=${gasCountTo}`)
    return data;
}

export const getPump = async (pumpId) => {
    const { data } = await $host.get('api/pump/' + pumpId)
    return data;
}

export const createPump = async (form) => {
    const { data } = await $host.post('api/pump', form)
    return data;
}

export const updatePump = async (form) => {
    const { data } = await $host.put('api/pump', form)
    return data;
}

export const removePump = async (pumpId) => {
    const { data } = await $host.delete('api/pump/' + pumpId)
    return data;
}