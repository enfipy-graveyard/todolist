import services from '@/services'
import {
  SET_IS_AUTHENTICATED,
  LOGIN, REGISTRATION,
  LOGOUT, CHECK_AUTH,
  FETCH, SAVE, TODOS_LOADING,
  SAVE_TODOS, AUTHORIZE,
  GET_TODOS, CHECK_AUTHORIZE,
  DELETE, EDIT, COMPLETE_TODO
} from '@/constants'

const getResponse = (context, body) => {
  if (body.length > 50) {
    context.commit(SET_IS_AUTHENTICATED, { authenticated: true })
    return { success: true }
  }
  return { success: false, error: body }
}

export default {
  [LOGIN] (context, creds) {
    return services.auth[LOGIN](creds)
      .then(res => getResponse(context, res.body))
  },

  [REGISTRATION] (context, creds) {
    return services.auth[REGISTRATION](creds)
      .then(res => getResponse(context, res.body))
  },

  [AUTHORIZE] (context) {
    context.commit(CHECK_AUTHORIZE, true)
    const authenticated = services.auth[AUTHORIZE]()
    if (authenticated) {
      context.dispatch(FETCH)
      context.commit(SET_IS_AUTHENTICATED, { authenticated })
    }
    context.commit(CHECK_AUTHORIZE, false)
  },

  [LOGOUT] (context) {
    services.auth[LOGOUT]()
    context.commit(SET_IS_AUTHENTICATED, { authenticated: false })
  },

  [CHECK_AUTH] (context) {
    const authenticated = services.auth[CHECK_AUTH]()
    context.commit(SET_IS_AUTHENTICATED, { authenticated })
  },

  [FETCH] (context) {
    context.commit(TODOS_LOADING, true)
    services.todos[GET_TODOS]().then((res) => {
      context.commit(SAVE_TODOS, res)
      context.commit(TODOS_LOADING, false)
    })
  },

  [SAVE] (context, payload) {
    services.todos[SAVE](payload).then((res) => {
      context.commit(SAVE, res)
    })
  },

  [DELETE] (context, payload) {
    services.todos[DELETE](payload).then(() => context.commit(DELETE, payload))
  },

  [COMPLETE_TODO] (context, payload) {
    services.todos[COMPLETE_TODO](payload).then(res => context.commit(COMPLETE_TODO, res.body))
  },

  [EDIT] (context, payload) {
    services.todos[EDIT](payload).then(res => context.commit(EDIT, res.body))
  },
}
