import sys
from nltk.tokenize import word_tokenize
import string
from nltk.corpus import stopwords
from nltk.stem import PorterStemmer
import nltk



def check_proper_nouns(sentence):
    tagged_words = nltk.pos_tag(nltk.word_tokenize(sentence))
    proper_nouns = [word for word, pos in tagged_words if pos == 'NNP']
    
    if len(proper_nouns) > 0:
        # print("Cümlede özel isim(ler) bulundu:")
        # for noun in proper_nouns:
        #     print(noun)
        print(len(proper_nouns))
    else:
        print("0")

# nltk.download('punkt')
# nltk.download('averaged_perceptron_tagger')

text = sys.argv[1]
check_proper_nouns(text)