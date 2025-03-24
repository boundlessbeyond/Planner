import { createAction, props } from '@ngrx/store';

export const authInitialize = createAction(
  '[AuthState] Init'
);
export const setIsAuthenticated = createAction(
  '[AuthState] Set Is Authenticated',
  props<{ isAuthenticated: boolean }>()
);
