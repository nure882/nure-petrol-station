import { $authhost, $host } from "./index.js";

export const getCustomers = async (name = "", surname = "", email = "") => {
    const { data } = await $host.get(`api/customer?name=${name}&surname=${surname}&email=${email}`)
    return data;
}

export const getCustomer = async (customerId) => {
    const { data } = await $host.get('api/customer/' + customerId)
    return data;
}