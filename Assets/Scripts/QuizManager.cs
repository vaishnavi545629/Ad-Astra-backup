using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;
using System.Text;

/*
 * manager to handle quiz logic (AI version - FIXED)
 */
public class QuizManager : MonoBehaviour
{
    [Header("AI")]
    private string apiKey = "Key"; /*Enter your API key here*/

    [Header("UI")]
    public TextMeshProUGUI questionText;
    public GameObject[] options;

    public AudioSource audioSource;
    public AudioClip winSound;

    public GameObject quizPanel;
    public GameObject winPanel;

    private int correctAnswerIndex = 0;

    // =========================
    // 🔥 CALLED FROM PLANET DROP
    // =========================
    public void GenerateAIQuestion(string planetName)
    {
        Debug.Log("AI Question requested for: " + planetName);
        StartCoroutine(CallGeminiAPI(planetName));
    }

    // =========================
    // 🔥 API CALL (FIXED JSON)
    // =========================
    IEnumerator CallGeminiAPI(string planet)
    {
        string url = "https://generativelanguage.googleapis.com/v1beta/models/gemini-flash-latest:generateContent?key=" + apiKey;

        string prompt =
            $"Generate a multiple choice question about {planet}. " +
            $"Give exactly 4 options. " +
            $"Return ONLY JSON like: " +
            $"{{\"question\":\"...\",\"options\":[\"...\",\"...\",\"...\",\"...\"],\"correctIndex\":0}}";

        string jsonBody = JsonUtility.ToJson(new RequestWrapper(prompt));

        UnityWebRequest request = new UnityWebRequest(url, "POST");

        byte[] bodyRaw = Encoding.UTF8.GetBytes(jsonBody);
        request.uploadHandler = new UploadHandlerRaw(bodyRaw);
        request.downloadHandler = new DownloadHandlerBuffer();

        request.SetRequestHeader("Content-Type", "application/json");

        yield return request.SendWebRequest();

        if (request.result == UnityWebRequest.Result.Success)
        {
            string response = request.downloadHandler.text;
            Debug.Log("API Response: " + response);

            ParseAndDisplay(response);
        }
        else
        {
            Debug.LogError("API Error: " + request.error);
            Debug.LogError("Full Response: " + request.downloadHandler.text);
        }
    }

    // =========================
    // 🔥 PARSE RESPONSE (IMPROVED)
    // =========================
    void ParseAndDisplay(string response)
    {
        try
        {
            // STEP 1: Parse full Gemini response
            GeminiResponse gemini = JsonUtility.FromJson<GeminiResponse>(response);

            // STEP 2: Get actual AI text
            string aiText = gemini.candidates[0].content.parts[0].text;

            Debug.Log("RAW AI TEXT: " + aiText);

            // STEP 3: Parse your quiz JSON
            AIResponse data = JsonUtility.FromJson<AIResponse>(aiText);

            // STEP 4: Display
            questionText.text = data.question;
            correctAnswerIndex = data.correctIndex;

            for (int i = 0; i < options.Length; i++)
            {
                options[i].transform.GetChild(0)
                    .GetComponent<TextMeshProUGUI>().text = data.options[i];

                options[i].GetComponent<Answer>().isCorrect = (i == correctAnswerIndex);
            }
        }
        catch (Exception e)
        {
            Debug.LogError("Parsing failed: " + e.Message);
            Debug.LogError("FULL RESPONSE: " + response);
        }
    }

    // =========================
    // 🧩 CORRECT ANSWER
    // =========================
    public void Correct()
    {
        Debug.Log("Correct Answer!");
        PlayWinSound();
    }

    // =========================
    // 🔊 SOUND
    // =========================
    private void PlayWinSound()
    {
        if (audioSource != null && winSound != null)
        {
            audioSource.clip = winSound;
            audioSource.Play();
        }
    }
}

// =========================
// 📦 SAFE REQUEST FORMAT
// =========================
[Serializable]
public class RequestWrapper
{
    public Content[] contents;

    public RequestWrapper(string prompt)
    {
        contents = new Content[]
        {
            new Content(prompt)
        };
    }
}

[Serializable]
public class Content
{
    public Part[] parts;

    public Content(string text)
    {
        parts = new Part[]
        {
            new Part(text)
        };
    }
}

[Serializable]
public class Part
{
    public string text;

    public Part(string t)
    {
        text = t;
    }
}

// =========================
// 📦 RESPONSE STRUCTURE
// =========================
[Serializable]
public class AIResponse
{
    public string question;
    public string[] options;
    public int correctIndex;
}

[Serializable]
public class GeminiResponse
{
    public Candidate[] candidates;
}

[Serializable]
public class Candidate
{
    public Content content;
}

