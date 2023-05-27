import nltk

nltk.download('punkt')

sentence = "NLTK paketi başarıyla yüklendi!"
tokens = nltk.word_tokenize(sentence)

print(tokens)