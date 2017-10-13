/*Name: Stephen Jeon* (055184139) Date: July 27, 2016 Course: OOP244 Instructor: Eden Burton 
Milestone 1 Assignment*/

#define _CRT_SECURE_NO_WARNINGS
#include <cstring>
#include <iomanip>
#include "Course.h"

using namespace std;

namespace sict{
	//Constructors
	Course::Course(){
		courseCode_[0] = 0;
		credits_ = 0;
		studyLoad_ = 0;
		courseTitle_ = nullptr;
	}
	//Four argument constructor validates each variable in the array and sets the values if it is valid.
	Course::Course(const char* code, const char* title, int credits, int study){
		if (strlen(title)!=0   && code[0] != '\0' && strlen(code) <= MAX_COURSECODE_LEN && credits > 0 && study > 0) {
			courseTitle_ = new char[strlen(title)];
			strcpy(courseTitle_, title);
			strcpy(courseCode_, code);
			credits_ = credits;
			studyLoad_ = study;
		}
		else{
			courseTitle_ = nullptr;
			courseCode_[0] = '\0';
			credits_ = 0;
			studyLoad_ = 0;
		}
	}
		
	//Copy constructor sets the initial values given from a class
	Course::Course(const Course& a){
		courseTitle_ = new char[strlen(a.courseTitle_)];
		strcpy(courseTitle_, a.courseTitle_);
		strcpy(courseCode_, a.courseCode_);
		credits_ = a.credits_;
		studyLoad_ = a.studyLoad_;
	}
	//destructor destroys the coursetitle dynamic array
	Course::~Course(){
			//delete[] courseTitle_;
	}

	//Setter Functions
	void Course::setcode(const char* code){
		strncpy(courseCode_, code, MAX_COURSECODE_LEN + 1);
	}

	void Course::settitle(const char* title){
		strcpy(courseTitle_, title);
	}

	void Course::setcredit(const int credits){
		credits_ = credits;
	}

	void Course::setstudy(const int study){
		studyLoad_ = study;
	}

	void Course:: display(ostream& pout){
		pout << left << courseCode_ << ' ' << '|' << ' ' << left << setw(20) << courseTitle_ << ' ' << '|' << ' ' << right << setw(6) << credits_ << ' ' << '|' << ' ' << right << setw(10) << studyLoad_;
	}

	//Getter Functions
	const char* Course::getCourseCode() const{
		return courseCode_;
	}

	const char* Course::getCourseTitle() const{
		return courseTitle_;
	}

	int Course::getCredits()const{
		return credits_;
	}

	int Course::getStudyLoad() const{
		return studyLoad_;
	}

	bool Course::isEmpty()const{
		//return true if the arrray is in a safe empty state.
		if (courseCode_[0] == 0 && credits_ == 0 && studyLoad_ == 0 && courseTitle_== nullptr){
			return true;
		}
		return false;
	}

	//Overload Operators
	bool Course::operator==(const char* code){
		//returns true if the strings are equal
		if (strcmp(code, courseCode_) == 0){
			return true;
		}
		return false;
	}

	int Course::operator +=(int study){
		studyLoad_ += study;

		return studyLoad_;
	}

	Course& Course::operator=(const Course& a){
		//if the object is not the same, sets the the values as a copier does
		if (this != &a){
			delete[] courseTitle_;
			courseTitle_ = new char[strlen(a.courseTitle_)];
			strcpy(courseTitle_, a.courseTitle_);
			strcpy(courseCode_, a.courseCode_);
			credits_ = a.credits_;
			studyLoad_ = a.studyLoad_;

			return *this;
		}
		return *this;
	}

	//Helper Function
	ostream& operator<<(std::ostream& pout, Course& a){
		//customizes << operator by calling the course display function.
		a.display(pout);
		return pout;
	}
}
