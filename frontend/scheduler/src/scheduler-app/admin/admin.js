import { combineReducers } from 'redux';

import people from './people/people';
import adminPositions from './positions/positions';

export default combineReducers({
  people,
  adminPositions
});
