/* AUTH */
export const API_URL = 'http://localhost:51602/'
export const LOGIN_URL = `${API_URL}api/gettoken`
export const SIGNUP_URL = `${API_URL}api/registration`
export const TODOS_URL = `${API_URL}api/todos`
export const ID_TOKEN = 'id_token'

/* MUTATION TYPES */
export const SET_IS_AUTHENTICATED = 'setIsAuthenticated'
export const SAVE_TODOS = 'saveTodos'
export const SAVE = 'save'

/* ACTIOn TYPES */
export const LOGIN = 'login'
export const REGISTRATION = 'registration'
export const LOGOUT = 'logout'
export const CHECK_AUTH = 'checkAuth'
export const GET_AUTH_HEADER = 'getAuthHeader'
export const FETCH = 'fetch'
export const GET_TODOS = 'getTodos'
