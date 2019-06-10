import moment from 'moment';

export const addThousandSeparator = (value) => {
    return value.toString().replace(/(\d)(?=(\d{3})+(?!\d))/g, '$1.');
};

export const getDateRangeString = (start, end) => {
    const starting = moment(new Date(start));
    const startingDate = starting.format('DD');
    const startingMonth = starting.format('MM');
    const startingYear = starting.format('YYYY');

    const ending = moment(new Date(end));
    const endingDate = ending.format('DD');
    const endingMonth = ending.format('MM');
    const endingYear = ending.format('YYYY');

    return `${ startingDate } tháng ${ startingMonth }, ${ startingYear } - ${ endingDate } tháng ${ endingMonth }, ${ endingYear }`;
};

export const getRandomValue = (min, max) => {
    return Math.floor(Math.random() * (max - min + 1) + min);
};

export const groupBy = (items, key) => items.reduce(
    (result, item) => ({
      ...result,
      [item[key]]: [
        ...(result[item[key]] || []),
        item,
      ],
    }),
    {},
);

export const isDateBetween = (check, start, end) => {
  const dCheck = new Date(check);
  const dStart = new Date(start);
  const dEnd = new Date(end);

  return dCheck >= dStart && dCheck <= dEnd;
};

export const isValidNumber = (value) => {
  return !isNaN(value);
};

export const getRandomColor = () => {
  const o = Math.round, r = Math.random, s = 255;
  return 'rgba(' + o(r()*s) + ',' + o(r()*s) + ',' + o(r()*s) + ', 0.3)';
}

export const sortBy = (function () {
  var toString = Object.prototype.toString,
      // default parser function
      parse = function (x) { return x; },
      // gets the item to be sorted
      getItem = function (x) {
        var isObject = x != null && typeof x === "object";
        var isProp = isObject && this.prop in x;
        return this.parser(isProp ? x[this.prop] : x);
      };

  /**
   * Sorts an array of elements.
   *
   * @param  {Array} array: the collection to sort
   * @param  {Object} cfg: the configuration options
   * @property {String}   cfg.prop: property name (if it is an Array of objects)
   * @property {Boolean}  cfg.desc: determines whether the sort is descending
   * @property {Function} cfg.parser: function to parse the items to expected type
   * @return {Array}
   */
  return function sortby (array, cfg) {
    if (!(array instanceof Array && array.length)) return [];
    if (toString.call(cfg) !== "[object Object]") cfg = {};
    if (typeof cfg.parser !== "function") cfg.parser = parse;
    cfg.desc = !!cfg.desc ? -1 : 1;
    return array.sort(function (a, b) {
      a = getItem.call(cfg, a);
      b = getItem.call(cfg, b);
      return cfg.desc * (a < b ? -1 : +(a > b));
    });
  };

}());