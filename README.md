# Azure Function header bug

### Reproduction steps:
1. Run the IsolatedApp project
2. Send a HTTP request to the Cache function
3. Inspect the response

### Expected outcome:
- Body should be "[]"
- Header "X-Text-Type" should be "json"

### Actual outcome:
- Body is "System.IO.MemoryStream"
- Header "X-Text-Type" is "System.String[]"