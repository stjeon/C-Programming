#define _CRT_SECURE_NO_WARNINGS
#include "general.h"
#include "ICTCourse.h"
#include <iostream>
#include <cstring>
#include <iomanip>

namespace sict{
	//default constructor sets the system value to matrix
	ICTCourse::ICTCourse(){
		char matrix[7] = "matrix";
		strcpy(computerSystem_, matrix);
	}

	//5 arg constructor sets the system value from the incoming parameter
	ICTCourse::ICTCourse(const char* code, const char* title, int credits, int study, const char* system): Course(code, title, credits, study){
		if (strlen(system) != 0){
			strcpy(computerSystem_, system);
			computerSystem_[6] = '\0';
		}
	}


	//4 argument constructor from the base class. Also initializes the system value to the default value
	ICTCourse::ICTCourse(const char* code, const char* title, int credits, int study) :Course(code, title, credits, study){
		char matrix[7] = "matrix";
		strcpy(computerSystem_, matrix);
	}

	//setter and getter function for computer systems
	const char* ICTCourse::getComputerSystem() const{
		return computerSystem_;
	}

	void ICTCourse::setComputerSystem(const char* value){
		strncpy(computerSystem_, value, 6);
			computerSystem_[7] = '\0';
	}
	//display and cout overload operators
	std::ostream& operator<<(std::ostream& pout, ICTCourse& a){
		a.display(pout);

		return pout;
	}

	void ICTCourse::display(ostream& pout){
		char temp[21];
		strncpy(temp, getCourseTitle(), 20);
		temp[20] = '\0';

		pout << left << getCourseCode() << ' ' << ' ' << '|' << ' ' << ' '
			<< left << setw(20) << temp << ' ' << ' ' << '|' << ' ' << ' '
			<< right << setw(6) << getCredits() << ' ' << ' ' << '|' << ' ' << ' '
			<< right << setw(4) << getStudyLoad() << ' ' << ' ' << '|' << ' ' << ' '
			<< left << setw(6) << getComputerSystem() << ' ' << ' ' << '|' << ' ' << ' ' << right
			<< setw(4)<< "    " << ' ' << ' ' << '|';
	}

	fstream& ICTCourse::store(fstream& fileStream, bool addNewLine) const{
		ofstream file("file.txt");
		if (file.is_open()){
			fileStream << TYPE_ICT << getCourseTitle() << ',' <<
				getCourseTitle() << ',' <<
				getCredits() << ',' <<
				getStudyLoad() << ',' <<
				getComputerSystem();
				if (addNewLine == true){
					fileStream << '\n';
				}
		}
		else cout << "Unable to open file";

		return fileStream;
	}

	ostream& ICTCourse::display(ostream& os) const{
		char temp[21];
		strncpy(temp, getCourseTitle(), 20);
		temp[20] = '\0';

		os << left << getCourseCode() << ' ' << ' ' << '|' << ' ' << ' '
			<< left << setw(20) << temp << ' ' << ' ' << '|' << ' ' << ' '
			<< right << setw(6) << getCredits() << ' ' << ' ' << '|' << ' ' << ' '
			<< right << setw(4) << getStudyLoad() << ' ' << ' ' << '|' << ' ' << ' '
			<< left << setw(6) << getComputerSystem() << ' ' << ' ' << '|' << ' ' << ' ' << right
			<< setw(4) << "    " << ' ' << ' ' << '|';

		return os;
	}

	istream& ICTCourse::read(istream& istr) {
		char code[MAX_COURSECODE_LEN + 1];//holder variable for the coursecode
		char title[51];//holder variable for the course title
		int credits, study;//holders for the credits and studyload
		char system[6];
		
		cout << "Course Code: ";
		istr >> code;
		cout << "Course Title: ";
		istr >> title;
		cout << "Credits: ";
		istr >> credits; 
		cout << "Study Load: ";
		istr >> study; 
		cout << "Computer System: ";
		istr >> system; 

		setcode(code);
		settitle(title);
		setcredit(credits);
		setstudy(study);
		setComputerSystem(system);

		return istr;
	}

	fstream& ICTCourse::load(fstream& fileStream){
		char code[MAX_COURSECODE_LEN + 1];//holder variable for the coursecode
		char title[51];//holder variable for the course title
		int credits, study;//holders for the credits and studyload
		char system[6];
		
		if (fileStream.is_open()){
			while (fileStream.good()){
				fileStream.getline(code, ',');
				fileStream.getline(title, ',');
				fileStream >> credits;
				fileStream.ignore(',');
				fileStream >> study;
				fileStream.ignore(',');
				fileStream.getline(system, ',');
			}
			setcode(code);
			settitle(title);
			setcredit(credits);
			setstudy(study);
			setComputerSystem(system);
		}
		else cout << "Unable to open file";

		return fileStream;
	}
}