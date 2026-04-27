(function () {
  const fallbackApiUrl = "http://localhost:5159/api";
  const configuredApiUrl = window.OPHELIA_API_BASE_URL || window.OPHELIA_CONFIG?.API_BASE_URL || fallbackApiUrl;

  window.OPHELIA_CONFIG = {
    ...(window.OPHELIA_CONFIG || {}),
    API_BASE_URL: String(configuredApiUrl).replace(/\/$/, "")
  };
})();