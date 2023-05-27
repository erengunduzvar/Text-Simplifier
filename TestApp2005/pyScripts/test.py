import sys
from nltk.tokenize import word_tokenize
import string
from nltk.corpus import stopwords
from nltk.stem import PorterStemmer
import nltk



nltk.download('stopwords')

input_file = r"C:\Users\eymen\Masaüstü\aa\input.txt"
output_file = r"C:\Users\eymen\Masaüstü\aa\output.txt"

# wordScore = sys.argv[1]
# wordThreshold = sys.argv[2]

with open(input_file, "r") as file:
    data = file.read()

#Clear Punctuation
data = data.translate(str.maketrans("", "", string.punctuation))

#Tokenize the text
tokens = word_tokenize(data)

#Clear Stop Words
stop_words = set(stopwords.words('english'))
filtered_tokens = [word for word in tokens if word.casefold() not in stop_words]


#Stemming
stemmer = PorterStemmer()
stemmed_words = [stemmer.stem(word) for word in filtered_tokens]

with open(output_file, "w") as file:
    file.write("")

with open("output.txt", "a") as file:
    for stem_words in stemmed_words:
        file.write(stem_words + "\n")
        print(stem_words)