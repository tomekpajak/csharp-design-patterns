using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace tp.Memento
{    
    interface IMemento<T> {
        T GetState();
    }
    class JsonMemento<T> : IMemento<T> {
        private string json;
        public JsonMemento(T state) => json = JsonConvert.SerializeObject(state);
        public T GetState() => JsonConvert.DeserializeObject<T>(json);
    }

    //Originator
    abstract class Memorable<T> {
        protected T state;
        public Memorable(T state) => this.state = state;
        public IMemento<T> CreateSnapshot() => new JsonMemento<T>(state);
        public void RestoreSnapshot(IMemento<T> memento) => state = memento.GetState();
    }

    //Concrete Originator
    class Survey : Memorable<SurveyState> {
        public string Name { get; set; }
        public Survey() : base(new SurveyState(new List<int>(), new List<string>()))
        {            
        }
        public void AddAnswer(int question, string answer) {
            state.Questions.Add(question);
            state.Answers.Add(answer);
        }

        public override string ToString() => String.Join(';', state.Questions.Select((value, idx) => $"{value}: {state.Answers[idx]}"));
    }

    class SurveyState {
        public List<int> Questions { get; set; }
        public List<string> Answers { get; set; }
        public SurveyState(List<int> questions, List<string> answers)
        {
            this.Questions = questions;
            this.Answers = answers;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Memento pattern demo...");

            List<IMemento<SurveyState>> surveySnapshot = new List<IMemento<SurveyState>>(); //Caretaker
            
            var survey = new Survey() { Name = "test" };
            survey.AddAnswer(1, "I like c#");
            survey.AddAnswer(2, "Yes");

            Console.WriteLine(survey);
            Console.WriteLine("---");

            surveySnapshot.Add(survey.CreateSnapshot());

            survey.AddAnswer(3, "No");

            Console.WriteLine(survey);
            Console.WriteLine("---");

            survey.RestoreSnapshot(surveySnapshot.Last());

            Console.WriteLine(survey);
            Console.WriteLine("---");
        }
    }
}
