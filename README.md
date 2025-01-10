# Examination System

A comprehensive Examination System designed to handle various exam scenarios efficiently. This project leverages object-oriented principles, such as inheritance, polymorphism, and generics, alongside essential design patterns and modern C# practices to create a robust application.

---

## Features

1. **Question Management**
   - A `Question` class represents questions with properties like `Body`, `Marks`, and `Header`.
   - Support for multiple question types:
     - True or False.
     - Choose One.
     - Choose All.
   - Implements a base `Question` class with inherited classes for each type.

2. **Custom Question List**
   - A `QuestionList` class inherits from `List<Question>` to manage collections of questions.
   - Overrides the `Add` method to log questions to a file specific to each `QuestionList`.
   - Utilizes `TextWriter` and `TextReader` for file operations.

3. **Answer Management**
   - `Answer` and `AnswerList` classes manage answers and their association with questions.

4. **Exam Management**
   - A base `Exam` class encapsulates common attributes:
     - `Time`, `NumberOfQuestions`, `QuestionAnswerDictionary`, and more.
   - Derived Exam Types:
     - `PracticeExam`: Displays correct answers after completion.
     - `FinalExam`: Only shows questions and answers.
   - Supports modes: `Starting`, `Queued`, `Finished`.

5. **Subject Association**
   - Each `Exam` object is associated with a `Subject` object for categorization.

6. **Generic Constraints**
   - Implements constraints to ensure type safety across classes.

7. **Utility Interfaces and Overrides**
   - Implements `ICloneable` and `IComparable` for cloning and comparison.
   - Overrides:
     - `ToString`: Provides meaningful string representations.
     - `Equals` and `GetHashCode`: Ensures object equality consistency.

8. **Event-Driven Notifications**
   - Notifies students when an exam enters the `Starting` mode using delegates and events.

9. **Object-Oriented Design**
   - The system is designed using OOP principles, making it modular, reusable, and easy to maintain.

10. **Event Handlers**
    - The system uses event handlers to manage and respond to various events, such as question creation and exam submission.

11. **Factory Design Pattern**
    - The Factory design pattern is used to create instances of different types of questions and exams, promoting code reusability and scalability.

12. **User Interaction**
   - Allows the end-user to select an exam type (Practice or Final) and displays the respective exam.


---
##DEMO
![DEMO](./Video.mp4)
## Project Structure

- **Abstract Classes**: Defines the contracts for exams and questions.
- **Classes**: Implements the Abstract Classes and provides concrete implementations for different types of exams and questions.
- **Factories**: Contains factory classes to create instances of exams and questions.
- **Event Handlers**: Manages events related to exams and questions.

---

## Getting Started

### Prerequisites
- .NET Framework or .NET Core (latest version).
- Visual Studio or any C# compatible IDE.

### Installation
1. Clone the repository:
   ```bash
   git clone https://github.com/YourUsername/ExaminationSystem.git
   ```
2. Open the solution file in your IDE.

3. Build the project to restore dependencies.



## Contributing

Contributions are welcome! Follow these steps:
1. Fork the repository.
2. Create a new branch:
   ```bash
   git checkout -b feature-name
   ```
3. Commit your changes:
   ```bash
   git commit -m "Add feature description"
   ```
4. Push to the branch:
   ```bash
   git push origin feature-name
   ```
5. Open a pull request.

---

## License

This project is licensed under the MIT License. See the [LICENSE](LICENSE) file for details.

---

## Contact

For inquiries or feedback, reach out to:

- **Name:** Muhammad Fawzi
- **Email:** imuhammadfawzi@gmail.com
- **LinkedIn:** [Your LinkedIn Profile](https://www.linkedin.com/in/imuhammadfawzi)

---
