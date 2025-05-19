using System;
using System.Collections.Generic;
using NAudio.Wave;

class CybersecurityBot
{
    static string userName = "Guest";
    static string userInterest = "";
    static string lastTopic = "";

    static Dictionary<string, string> keywordResponses = new Dictionary<string, string>
    {
        { "password", "Make sure to use strong, unique passwords for each account. Avoid using personal details." },
        { "scam", "Watch out for online scams. Never click suspicious links or share personal information with unknown sources." },
        { "privacy", "Protect your privacy by reviewing your app permissions and adjusting your account security settings." },
        { "firewall", "A firewall helps prevent unauthorized access to or from a private network. Always keep it enabled." }
    };

    static List<string> phishingTips = new List<string>
    {
        "Be cautious of emails asking for personal info. Check the sender's email.",
        "Never click on links in suspicious messages, even if they look official.",
        "Hover over links to preview URLs before clicking.",
        "Avoid downloading attachments from unknown sources."
    };

    static void Main(string[] args)
    {
        // Display a visually enhanced chatbot UI
        DisplayConsoleUI();

        // Play a voice greeting at the start
        PlayGreetingAudio();
        ShowASCIIArt();
        WelcomeUser();
        RespondToQuestions();
    }

    // Show the ASCII Art logo or symbol for the chatbot
    static void ShowASCIIArt()
    {
        string asciiArt = @"
  .----------------.  .----------------.  .----------------.  .----------------.  .----------------.  .----------------.  .----------------.  .----------------. 
| .--------------. || .--------------. || .--------------. || .--------------. || .--------------. || .--------------. || .--------------. || .--------------. |
| |     ______   | || |  ____  ____  | || |   ______     | || |  _________   | || |  _______     | || |   ______     | || |     ____     | || |  _________   | |
| |   .' ___  |  | || | |_  _||_  _| | || |  |_   _ \    | || | |_   ___  |  | || | |_   __ \    | || |  |_   _ \    | || |   .'    `.   | || | |  _   _  |  | |
| |  / .'   \_|  | || |   \ \  / /   | || |    | |_) |   | || |   | |_  \_|  | || |   | |__) |   | || |    | |_) |   | || |  /  .--.  \  | || | |_/ | | \_|  | |
| |  | |         | || |    \ \/ /    | || |    |  __'.   | || |   |  _|  _   | || |   |  __ /    | || |    |  __'.   | || |  | |    | |  | || |     | |      | |
| |  \ `.___.'\  | || |    _|  |_    | || |   _| |__) |  | || |  _| |___/ |  | || |  _| |  \ \_  | || |   _| |__) |  | || |  \  `--'  /  | || |    _| |_     | |
| |   `._____.'  | || |   |______|   | || |  |_______/   | || | |_________|  | || | |____| |___| | || |  |_______/   | || |   `.____.'   | || |   |_____|    | |
| |              | || |              | || |              | || |              | || |              | || |              | || |              | || |              | |
| '--------------' || '--------------' || '--------------' || '--------------' || '--------------' || '--------------' || '--------------' || '--------------' |
 '----------------'  '----------------'  '----------------'  '----------------'  '----------------'  '----------------'  '----------------'  '----------------' ";
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine(asciiArt);
        Console.ResetColor();
    }

    // Display the enhanced console UI with structured formatting
    static void DisplayConsoleUI()
    {
        Console.BackgroundColor = ConsoleColor.Black;
        Console.ForegroundColor = ConsoleColor.White;
        Console.Clear();

        // Add some formatting for readability
        Console.WriteLine("\n===============================");
        Console.WriteLine("Cybersecurity Awareness Bot");
        Console.WriteLine("===============================");
    }

    // Play a greeting audio when the program starts using NAudio
    static void PlayGreetingAudio()
    
    {
        try
        {
            string filePath = @"greeting.wav"; // Change this to your actual path
            using (var audioFile = new AudioFileReader(filePath))
            using (var outputDevice = new WaveOutEvent())
            {
                outputDevice.Init(audioFile);
                outputDevice.Play();

                // Wait until the audio has finished playing
                while (outputDevice.PlaybackState == PlaybackState.Playing)
                {
                    System.Threading.Thread.Sleep(100);
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error playing greeting audio: " + ex.Message);
        }
    }

    static void ShowASCIIArt()
    {
        string asciiArt = @"
  .----------------.  .----------------.  .----------------.  .----------------. 
 | .--------------. || .--------------. || .--------------. || .--------------. |
 | |   ______     | || |  ____  ____  | || |   ______     | || |  _________   | |
 | |  |_   __ \   | || | |_  _||_  _| | || |  |_   _ \    | || | |_   ___  |  | |
 | |    | |__) |  | || |   \ \  / /   | || |    | |_) |   | || |   | |_  \_|  | |
 | |    |  ___/   | || |    \ \/ /    | || |    |  __'.   | || |   |  _|  _   | |
 | |   _| |_      | || |    _|  |_    | || |   _| |__) |  | || |  _| |___/ |  | |
 | |  |_____|     | || |   |______|   | || |  |_______/   | || | |_________|  | |
 | '--------------' || '--------------' || '--------------' || '--------------' |
  '----------------'  '----------------'  '----------------'  '----------------' ";
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine(asciiArt);
        Console.ResetColor();
    }

    static void WelcomeUser()
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("Welcome to the Cybersecurity Awareness Bot!");
        Console.ResetColor();

        Console.Write("What is your name? ");
        string name = Console.ReadLine();

        Console.WriteLine($"Hello, {userName}! I'm here to help you stay safe online.");
        Console.WriteLine("Ask me anything about cybersecurity!");
    }

    static void RespondToQuestions()
    {
        string input = "";
        while (true)
        {
            Console.Write("\nYou: ");
            input = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(input))
            {
                Console.WriteLine("Bot: I didn't quite understand that. Could you rephrase?");
                continue;
            }

            string lowerInput = input.ToLower();

            if (lowerInput == "exit") break;

            // Sentiment detection
            if (lowerInput.Contains("worried"))
            {
                Console.WriteLine("Bot: It's okay to feel that way. Cybersecurity can be scary, but I'm here to help.");
                continue;
            }
            else if (lowerInput.Contains("curious"))
            {
                Console.WriteLine("Bot: Curiosity is great! Ask me anything about cybersecurity.");
                continue;
            }
            else if (lowerInput.Contains("frustrated"))
            {
                Console.WriteLine("Bot: I understand your frustration. Let’s take it one step at a time.");
                continue;
            }

            // Store user interest
            if (lowerInput.Contains("interested in"))
            {
                int idx = lowerInput.IndexOf("interested in") + "interested in".Length;
                userInterest = input.Substring(idx).Trim();
                Console.WriteLine($"Bot: Great! I'll remember that you're interested in {userInterest}.");
                lastTopic = userInterest;
                continue;
            }

            if (lowerInput.Contains("remind me") && !string.IsNullOrEmpty(userInterest))
            {
                Console.WriteLine($"Bot: You mentioned you're interested in {userInterest}. Would you like to learn more?");
                continue;
            }

            if (lowerInput.Contains("more info") && !string.IsNullOrEmpty(lastTopic))
            {
                Console.WriteLine($"Bot: Here's more on {lastTopic}: {GetExtendedInfo(lastTopic)}");
                continue;
            }

            if (lowerInput.Contains("phishing tip"))
            {
                Random rand = new Random();
                int index = rand.Next(phishingTips.Count);
                Console.WriteLine("Bot: " + phishingTips[index]);
                lastTopic = "phishing";
                continue;
            }

            if (HandleKeywordResponse(lowerInput)) continue;

            // Command handling
            switch (lowerInput)
            {
                StartQuiz();
                    break;
                case "security tip":
                ShowSecurityTip();
                    break;
                case "news":
                ShowCybersecurityNews();
                    break;
                case "checklist":
                ShowSecurityChecklist();
                    break;
                case "myths":
                ShowCybersecurityMyths();
            }
        }
    }

    static bool HandleKeywordResponse(string input)
            {
        foreach (var keyword in keywordResponses.Keys)
        {
            if (input.Contains(keyword))
            {
                Console.WriteLine("Bot: " + keywordResponses[keyword]);
                lastTopic = keyword;
                return true;
            }
        }
    }

    // Display a random security tip
    static void ShowSecurityTip()
    {
        string[] tips = new string[]
        {
            "Tip: Always enable two-factor authentication on your accounts.",
            "Tip: Never share your passwords with anyone, even if they claim to be from a trusted organization.",
            "Tip: Make sure your software is up-to-date to avoid known vulnerabilities.",
            "Tip: Be cautious about public Wi-Fi networks. Use a VPN when connecting to public Wi-Fi.",
            "Tip: Always check the URL of a website before entering sensitive information to ensure it's legitimate."
        };

        Random rand = new Random();
        int randomIndex = rand.Next(tips.Length);
        Console.WriteLine($"\nSecurity Tip of the Day: {tips[randomIndex]}");
    }

    // Display the latest cybersecurity news
    static void ShowCybersecurityNews()
    {
        Console.WriteLine("\nLatest Cybersecurity News:");
        // Sample data, ideally would be fetched from an API or web source
        string[] newsArticles = new string[]
        {
            "Data breach affects 5 million users: Company X apologizes for the incident.",
            "New malware discovered that targets banking apps.",
            "Security researchers uncover a major vulnerability in popular antivirus software.",
            "Hackers exploit weak passwords to breach over 100 corporate accounts."
        };

        foreach (var article in newsArticles)
        {
            Console.WriteLine($"- {article}");
        }
    }

    // Display the cybersecurity security checklist
    static void ShowSecurityChecklist()
    {
        Console.WriteLine("\nCybersecurity Security Checklist:");
        Console.WriteLine("1. Enable Two-Factor Authentication (2FA) on all your accounts.");
        Console.WriteLine("2. Use strong, unique passwords for each account.");
        Console.WriteLine("3. Regularly update your software and operating systems.");
        Console.WriteLine("4. Be cautious of suspicious emails and links (Phishing).");
        Console.WriteLine("5. Install and update antivirus software on your devices.");
        Console.WriteLine("6. Backup your important data regularly.");
        Console.WriteLine("7. Use a Virtual Private Network (VPN) when browsing on public networks.");
    }

    // Display common cybersecurity myths
    static void ShowCybersecurityMyths()
    {
        Console.WriteLine("\nCommon Cybersecurity Myths:");

        string[] myths = new string[]
        {
            "Myth: Mac computers don't need antivirus software.",
            "Myth: Strong passwords are enough to protect your accounts.",
            "Myth: Public Wi-Fi is always safe as long as you’re not doing anything sensitive.",
            "Myth: Cybersecurity is only a concern for big companies and organizations."
        };

        foreach (var myth in myths)
        {
            Console.WriteLine($"- {myth}");
        }

        Console.WriteLine("\nMake sure you verify information and learn the facts to stay safe online!");
    }

    // Start a basic cybersecurity quiz
    static void StartQuiz()
    {
        Console.WriteLine("\nWelcome to the Cybersecurity Quiz!");
        int score = 0;

        // Question 1
        Console.WriteLine("\n1. What is the best way to protect your password?");
        Console.WriteLine("a) Use your name\nb) Use a combination of letters, numbers, and symbols\nc) Use your birthday");
        Console.Write("Your answer: ");
        string answer = Console.ReadLine().ToLower();
        if (answer == "b") score++;

        // Question 2
        Console.WriteLine("\n2. What should you do if you receive a suspicious email?");
        Console.WriteLine("a) Open it and check the attachments\nb) Click on any links to verify the source\nc) Ignore it or report it to your email provider");
        Console.Write("Your answer: ");
        answer = Console.ReadLine().ToLower();
        if (answer == "c") score++;

        // Question 3
        Console.WriteLine("\n3. What is phishing?");
        Console.WriteLine("a) A type of fishing hobby\nb) A scam to steal personal information\nc) A way to secure passwords");
        Console.Write("Your answer: ");
        answer = Console.ReadLine().ToLower();
        if (answer == "b") score++;

        // Additional questions
        Console.WriteLine("\n4. What is a firewall?");
        Console.WriteLine("a) A software that monitors and controls incoming and outgoing network traffic\nb) A type of anti-virus software\nc) A security measure for physical walls");
        Console.Write("Your answer: ");
        answer = Console.ReadLine().ToLower();
        if (answer == "a") score++;

        Console.WriteLine("\n5. Which of these is NOT a safe practice?");
        Console.WriteLine("a) Using the same password for multiple accounts\nb) Enabling Two-Factor Authentication\nc) Regularly updating your software");
        Console.Write("Your answer: ");
        answer = Console.ReadLine().ToLower();
        if (answer == "a") score++;

        // Display result
        Console.WriteLine($"\nYour score: {score}/5");
        if (score == 5) Console.WriteLine("Excellent! You're a cybersecurity expert!");
        else if (score > 3) Console.WriteLine("Great job! You're on the right track!");
        else Console.WriteLine("Looks like you need to brush up on your cybersecurity knowledge.");
    }
}
