import { createFeatureSelector, createSelector } from "@ngrx/store";
import { AUTH_FEATURE_KEY, AuthState } from "./interfaces";

export const selectAuthState = createFeatureSelector<AuthState>(AUTH_FEATURE_KEY);
export const selectIsAuthenticated = createSelector(selectAuthState, (s) => s.isAuthenticated);
