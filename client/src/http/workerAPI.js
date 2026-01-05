import { $authhost, $host } from "./index.js";

export const getWorkers = async (name = "", surname = "", email = "", stationId = 0) => {
    const { data } = await $host.get(`api/worker?name=${name}&surname=${surname}&email=${email}&stationId=${stationId}`)
    return data;
}

export const getWorker = async (workerId) => {
    const { data } = await $host.get('api/worker/' + workerId)
    return data;
}

export const updateWorker = async (obj) => {
    const { data } = await $host.put('api/worker', obj);
    console.log(data)
}