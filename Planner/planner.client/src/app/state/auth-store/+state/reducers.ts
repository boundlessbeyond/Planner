import { Action, ActionReducer, createReducer, on } from '@ngrx/store';
import { AuthState } from './interfaces';
import { setIsAuthenticated } from './actions';
import { initialState } from './init';

const authReducer: ActionReducer<AuthState, Action> = createReducer(
  initialState,
  on(setIsAuthenticated, (state, { isAuthenticated }): AuthState => ({ ...state, isAuthenticated: isAuthenticated })),
);

export function reducer(state: AuthState, action: Action) {
  return authReducer(state, action);
}
