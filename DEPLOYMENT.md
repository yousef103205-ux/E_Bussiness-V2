# Ophelia E-Business Deployment

This repository is prepared for a static frontend deployment on Vercel from the project root.

## Vercel settings

- Framework Preset: Other
- Root Directory: ./
- Build Command: npm run build
- Output Directory: .
- Install Command: echo no install

No `vercel.json` is required for this static frontend. If one is added later, keep it minimal and valid JSON.

## Frontend

The Vercel entry point is `index.html` in the root folder. It uses the same real homepage content as `landing-page.html`. Static assets are loaded with relative paths such as `Photos/...`, `main.css`, `features.css`, `main.js`, and `features.js`.

## API configuration

`config.js` centralizes the frontend API base URL. The local fallback is:

```js
http://localhost:5159/api
```

When the backend is hosted later, update `config.js` with the hosted API URL, or set `window.OPHELIA_API_BASE_URL` before loading `config.js`.

## Backend

`Ophelia.Api/` is preserved in the project root, but Vercel should deploy only the static frontend. The ASP.NET Core API and SQL Server database need separate hosting later, for example Render, Railway, Azure, or another .NET-capable hosting platform. Backend-only features require that hosted API and online database to be available.