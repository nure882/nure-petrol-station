import { $authhost, $host } from "./index.js";

export const getStations = async (city = "", address = "") => {
    const { data } = await $host.get(`api/station?city=${city}&address=${address}`)
    return data;
}

export const getStation = async (id) => {
    const { data } = await $host.get(`api/station/${id}`)
    return data;
}

export const createStation = async (form) => {
    const { data } = await $host.post('api/station', form)
    return data;
}

export const updateStation = async (form) => {
    const { data } = await $host.put('api/station', form)
    return data;
}

export const removeStation = async (stationId) => {
    const { data } = await $host.delete('api/station/' + stationId)
    return data;
}