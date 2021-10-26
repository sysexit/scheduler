import React from 'react';

const DayTotal = () => (
  <div class="table-row table-foot">
    <div class="table-cell hour-cell"></div>
    {[...Array(23)].map((x, hour) => {
      if (hour < 4 || hour > 20) return;
      return <div class="table-cell hour-cell"></div>;
    })}
  </div>
);

export default DayTotal;
