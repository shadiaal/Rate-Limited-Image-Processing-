
# Rate-Limited Image Processing API with Caching

## Description
This project implements a RESTful API that allows users to upload an image, apply simple filters (e.g., grayscale, sepia), and manage API keys for authentication. It includes features such as rate limiting, caching for performance optimization, and file handling for image processing.

## Setup

1. Clone the repository:
   ```bash
   git clone https://github.com/username/Rate-Limited-Image-Processing-.git
   cd Rate-Limited-Image-Processing-
   ```

2. Install dependencies:
   ```bash
   dotnet restore
   ```

3. Run the application:
   ```bash
   dotnet run
   ```

## API Endpoints

- **POST /api/images/process**: Uploads an image and applies a filter.
  - Requires `API-Key` in the headers and `filter` as a query parameter.
  - Example:
    ```bash
    curl -X POST https://localhost:7165/api/images/process?filter=grayscale       -H "API-Key: YOUR_API_KEY"       -F "image=@path_to_image.jpg"
    ```

- **POST /api/apikeys/generate**: Generates a new unique API key.
  - Example:
    ```bash
    curl -X POST https://localhost:7165/api/apikeys/generate
    ```

## Features

- **Rate Limiting**: Limit requests per API key within a specific time window.
- **Caching**: Processed images are cached to avoid reprocessing.
- **Image Filters**: Supports filters like `grayscale` and `sepia`.

