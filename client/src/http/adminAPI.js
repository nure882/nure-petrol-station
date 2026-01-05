import { $authhost, $host } from "./index.js";

export const getAdmins = async (name = "", email = "", stationId = 0) => {
    const { data } = await $host.get(`api/admin?name=${name}&email=${email}&stationId=${stationId}`)
    return data;
}

export const getAdmin = async (adminId) => {
    const { data } = await $host.get('api/admin/' + adminId)
    return data;
}

export const updateAdmin = async (obj) => {
    const { data } = await $host.put('api/admin', obj);
    console.log(data)
}