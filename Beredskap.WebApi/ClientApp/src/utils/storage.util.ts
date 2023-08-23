/*
 * store an item to local storage
 *
 * @param string key
 * @param any value
 * @return void
 */
export const saveToStorage = (key: string, value: string) => {
  localStorage.removeItem(key);
  localStorage.setItem(key, value);
};

/*
 * remove an item out of local storage
 *
 * @param string key
 * @return void
 */
export const removeFromStorage = (key: string) => {
  localStorage.removeItem(key);
};

/*
 * retrieve an item from local storage
 *
 * @param string key
 * @return any
 */
export const retrieveFromStorage = (key: string) => {
  return localStorage.getItem(key);
};

/*
 * store an item to session storage
 *
 * @param string key
 * @param any value
 * @return void
 */
export const saveToSession = (key: string, value: any) => {
  sessionStorage.removeItem(key);
  sessionStorage.setItem(key, value);
};

/*
 * remove an item out of session storage
 *
 * @param string key
 * @return void
 */
export const removeFromSession = (key: string) => {
  sessionStorage.removeItem(key);
};

/*
 * retrieve an item from session storage
 *
 * @param string key
 * @return any
 */
export const retrieveFromSession = (key: string) => {
  return sessionStorage.getItem(key);
};

export const saveToCookie = (
  key: string,
  value: any,
  expireSecond: number
): string => {
  const d = new Date();
  d.setTime(d.getTime() + expireSecond * 1000);
  return (document.cookie = `${key}=${value}; expires=${d.toUTCString()}; path=/;`);
};

export const removeFromCookie = (key: string): string => {
  return (document.cookie = `${key}=; expires=Thu, 01 Jan 1970 00:00:00 UTC; path=/;`);
};

export const retrieveFromCookie = (key: string): any => {
  const allCookies = document.cookie;
  return allCookies
    .split('; ')
    .find((row) => row.startsWith(`${key}=`))
    ?.split('=')[1];
};
