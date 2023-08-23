export function naturalSortByProperty(arr: any, propertyName:string) {
  return arr.sort((a: any, b:any) => {
    const aValue = a[propertyName];
    const bValue = b[propertyName];
    
    const regExp = /\d+/g;
    const aDigits = aValue.match(regExp);
    const bDigits = bValue.match(regExp);

    if (aDigits && bDigits) {
      const aNumber = parseInt(aDigits[0]);
      const bNumber = parseInt(bDigits[0]);

      if (aNumber !== bNumber) {
        return aNumber - bNumber;
      }
    }

    return aValue.localeCompare(bValue);
  });
}
