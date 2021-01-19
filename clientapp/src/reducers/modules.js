import { ACTION_TYPES } from '../actions/organization/module';
const initialState = {
  list: [],
};

export const modules = (state = initialState, action) => {
  switch (action.type) {
    case ACTION_TYPES.FETCH_ALL:
      return {
        ...state,
        list: [...action.payload],
      };

    case ACTION_TYPES.CREATE:
      return {
        ...state,
        list: [...state.list, action.payload],
      };

    case ACTION_TYPES.UPDATE:
      return {
        ...state,
        list: state.list.map((x) => (x.ids === action.payload.id ? action.payload : x)),
      };

    case ACTION_TYPES.DELETE:
      return {
        ...state,
        list: state.list.filter((x) => x.ids !== action.payload),
      };

    default:
      return state;
  }
};
