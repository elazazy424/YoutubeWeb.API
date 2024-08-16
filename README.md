### Project Description

This project is a .NET-based API developed using a 3-tier architecture that consists of the following layers: Presentation Layer (PL), Business Logic Layer (BLL), and Data Access Layer (DAL). The project was designed with best practices such as:

- **Swagger Documentation**: For API documentation, allowing easy testing and visualization of the endpoints.
- **DTOs (Data Transfer Objects)**: Used to structure data between layers, promoting clean and efficient data handling.
- **Middlewares**: Implemented for global exception handling, ensuring any unexpected errors are caught and managed gracefully.
- **AutoMapper**: Used for object-to-object mapping, making it easier to convert between DTOs and models.
- **Error API Responses**: Integrated for consistent error handling across the API, improving clarity for both developers and consumers of the API.
- **YouTube API Integration**: The application integrates the YouTube Data API v3 to allow for search functionality. API keys are used to authenticate and retrieve data from YouTube.

### Steps to Obtain YouTube API Keys and Add to `appsettings.json`

1. **Create a Google Cloud Project**:
   - Visit the [Google Cloud Console](https://console.cloud.google.com/).
   - Create a new project by clicking on the project dropdown and selecting "New Project."
   
2. **Enable YouTube Data API**:
   - After selecting your project, navigate to the **APIs & Services** section.
   - Click on **Enable APIs and Services**.
   - Search for "YouTube Data API v3" and enable it.

3. **Create API Credentials**:
   - In the same **APIs & Services** section, click on **Credentials**.
   - Select **Create Credentials** and choose **API key**.
   - Google will generate an API key that you can copy.

4. **Restrict API Key (Optional but Recommended)**:
   - In the **Credentials** section, click on the API key you created.
   - You can restrict the API key by setting the allowed domains, IP addresses, or the APIs it can access (such as only allowing the YouTube Data API).

5. **Add API Key to `appsettings.json`**:
   - In your project, open the `appsettings.json` file.
   - Add the API key like this:

   ```json
   {
     "YouTube": {
       "ApiKey": "YOUR_YOUTUBE_API_KEY",
       "ApplicationName": "YOUR_YOUTUBE_NAME_KEY"
     }
   }
   ```



