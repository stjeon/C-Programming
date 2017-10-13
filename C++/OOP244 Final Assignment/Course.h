/*Name: Stephen Jeon* (055184139) Date: July 27, 2016 Course: OOP244 Instructor: Eden Burton
Milestone 1 Assignment*/
#include "general.h"
#ifndef SICT_Course_h_
#define SICT_Course_h_
#include <iostream>
#include "Streamable.h"
using namespace std;

namespace sict{
class Course:public Streamable{
	char courseCode_[MAX_COURSECODE_LEN + 1];
	char *courseTitle_;
	int credits_;
	int studyLoad_;

public:
	//Constructors and operators
	Course();
	Course(const char* code, const char* title, int credits, int study);
	Course(const Course& a);
	~Course();
	//Overload Operators
	Course& operator=(const Course& a);
	bool operator==(const char* code);
	int operator +=(int study);
	//Setter Functions
	void setcode(const char* code);
	void settitle(const char* title);
	void setcredit(const int credits);
	void setstudy(const int study);
	virtual void display(ostream& pout)=0;//set display to virtual
	//Getter Functions
	const char* getCourseCode() const;
	const char* getCourseTitle() const;
	int getCredits() const;
	int getStudyLoad() const;
	bool isEmpty() const;
};
//Helper Functions
std::ostream& operator<<(std::ostream& pout, Course& a);
}
#endif
