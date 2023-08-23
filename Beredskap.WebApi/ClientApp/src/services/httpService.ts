import axios from 'axios';
import AppConsts from '../lib/appconst';

const qs = require('qs');

const http = axios.create({
  baseURL: AppConsts.remoteServiceBaseUrl,
  timeout: 30000,
  paramsSerializer: function (params) {
    return qs.stringify(params, {
      encode: false,
    });
  },
});

export default http;