#define _CRT_SECURE_NO_WARNINGS
#include "general.h"
#include "GenEdCourse.h"
#include <iostream>
#include <cstring>
#include <iomanip>

namespace sict{
	//default constructor sets language level to 0
	GenEdCourse::GenEdCourse(){
		langlevel_ = 0;
	}

	//checks if the incoming language value is in range and copies if so
	GenEdCourse::GenEdCourse(const char* code, const char* title, int credits, int study, const int lang) : Course(code, title, credits, study){
		if (lang< 6 && lang>= 0){
			langlevel_ = lang;
		}
		else langlevel_ = 0;
	}

	GenEdCourse::GenEdCourse(const char* code, const char* title, int credits, int study) :Course(code, title, credits, study){
		langlevel_ = 0;
	}

	//setter and getter functions
	int GenEdCourse::getLangLevel()const{
		return langlevel_;
	}

	void GenEdCourse::setLangLevel(int value){
		if (value < 6 && value >= 0){
			langlevel_ = value;
		}
		else langlevel_ = 0;
	}

	//cout overload and display function
	std::ostream& operator<<(std::ostream& pout, GenEdCourse& a){
		a.display(pout);

		return pout;
	}

	void GenEdCourse::display(ostream& pout){
		char temp[21];
		strncpy(temp, getCourseTitle(), 20);
		temp[20] = '\0';

		pout << left << getCourseCode() << ' ' << ' ' << '|' << ' ' << ' '
			<< left << setw(20) << temp << ' ' << ' ' << '|' << ' ' << ' '
			<< right << setw(6) << getCredits() << ' ' << ' ' << '|' << ' ' << ' '
			<< right << setw(4) << getStudyLoad() << ' ' << ' ' << '|' << ' ' << ' '
			<< left << setw(6) << "      " << ' ' << ' ' << '|' << ' ' << ' ' << setw(4)
			<< right << getLangLevel() << ' ' << ' ' << '|';

	}

	fstream& GenEdCourse::store(fstream& fileStream, bool addNewLine) const{
		ofstream file("file.txt");
		if (file.is_open()){
			fileStream << TYPE_GEN << getCourseTitle() << ',' <<
				getCourseTitle() << ',' <<
				getCredits() << ',' <<
				getStudyLoad() << ',' <<
				getLangLevel();
			if (addNewLine == true){
				fileStream << '\n';
			}
		}
		else cout << "Unable to open file";

		return fileStream;
	}

	ostream& GenEdCourse::display(ostream& os) const{
		char temp[21];
		strncpy(temp, getCourseTitle(), 20);
		temp[20] = '\0';

		os << left << getCourseCode() << ' ' << ' ' << '|' << ' ' << ' '
			<< left << setw(20) << temp << ' ' << ' ' << '|' << ' ' << ' '
			<< right << setw(6) << getCredits() << ' ' << ' ' << '|' << ' ' << ' '
			<< right << setw(4) << getStudyLoad() << ' ' << ' ' << '|' << ' ' << ' '
			<< left << setw(6) << getLangLevel() << ' ' << ' ' << '|' << ' ' << ' ' << right
			<< setw(4) << "    " << ' ' << ' ' << '|';

		return os;
	}

	istream& GenEdCourse::read(istream& istr){
		char code[MAX_COURSECODE_LEN + 1];//holder variable for the coursecode
		char title[51];//holder variable for the course title
		int credits, study;//holders for the credits and studyload
		int lang; //holder for the language level

		cout << "Course Code: ";
		istr >> code;
		cout << "Course Title: ";
		istr >> title;
		cout << "Credits: ";
		istr >> credits;
		cout << "Study Load: ";
		istr >> study;
		cout << "Language Requirement: ";
		istr >> lang;

		setcode(code);
		settitle(title);
		setcredit(credits);
		setstudy(study);
		setLangLevel(lang);

		return istr;
	}

	fstream& GenEdCourse::load(fstream& fileStream){
		char code[MAX_COURSECODE_LEN + 1];//holder variable for the coursecode
		char title[51];//holder variable for the course title
		int credits, study;//holders for the credits and studyload
		int lang; //holder for the language level

		if (fileStream.is_open()){
			while (fileStream.good()){
				fileStream.getline(code, ',');
				fileStream.getline(title, ',');
				fileStream >> credits;
				fileStream.ignore(',');
				fileStream >> study;
				fileStream.ignore(',');
				fileStream >> lang;
				fileStream.ignore(',');
			}
			setcode(code);
			settitle(title);
			setcredit(credits);
			setstudy(study);
			setLangLevel(lang);
		}
		else cout << "Unable to open file";

		return fileStream;
	}
}