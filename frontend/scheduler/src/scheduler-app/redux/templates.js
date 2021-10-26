import { createAsyncThunk, createSlice } from '@reduxjs/toolkit';
import { TemplateAPI } from '../services';

export const LOAD_TEMPLATES = 'templates/load';
export const loadTemplates = createAsyncThunk(LOAD_TEMPLATES, async () => {
  const response = await TemplateAPI.get();
  return response.data.templates;
});

export const ADD_TEMPLATE = 'templates/add';
export const addTemplate = createAsyncThunk(
  ADD_TEMPLATE,
  async ({ template }, { dispatch, getState }) => {
    await TemplateAPI.create(template);
    dispatch(loadTemplates());
  }
);

export const UPDATE_TEMPLATE = 'templates/update';
export const updateTemplate = createAsyncThunk(
  UPDATE_TEMPLATE,
  async ({ template }, { dispatch, getState }) => {
    await TemplateAPI.update(template);
    dispatch(loadTemplates());
  }
);

export const templatesSlice = createSlice({
  name: 'templates',
  initialState: [],
  reducers: {},
  extraReducers: {
    [loadTemplates.fulfilled]: (state, { payload }) => (state = payload)
  }
});

export default templatesSlice.reducer;
