const formatDateToYYYYMMDD = (dateString) => {
    const inputDate = new Date(dateString);
  
    const year = inputDate.getFullYear();
    const month = String(inputDate.getMonth() + 1).padStart(2, '0'); // Months are 0-indexed, so add 1 and pad to 2 digits
    const day = String(inputDate.getDate()).padStart(2, '0');
    return `${year}-${month}-${day}`;
  }

export default formatDateToYYYYMMDD;