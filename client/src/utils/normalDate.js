export const normalizeDate = (inputDate) => {
    const date = new Date(inputDate);
    const options = { weekday: 'short', year: 'numeric', month: 'numeric', day: 'numeric' };
    return date.toLocaleDateString('en-us', options);
}

export default normalizeDate;