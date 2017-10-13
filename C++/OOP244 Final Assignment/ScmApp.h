/*Name: Stephen Jeon* (055184139) Date: July 27, 2016 Course: OOP244 Instructor: Eden Burton
Milestone 1 Assignment*/
#include "general.h"
#include "Course.h"
#ifndef SICT_ScmApp_h_
#define SICT_ScmApp_h_

namespace sict{
	class ScmAppTester;
	class ScmApp{
		char filename_[256];
		fstream datafile_;
		Course* courseList_[MAX_NO_RECS];
		int noOfCourses_;
		ScmApp(const ScmApp&) = delete;
		ScmApp& operator=(const ScmApp&) = delete;
		//Private Member Functions
		void pause() const;
		int menu();
		void listCourses() const;
		int searchForACourse(const char* courseCode) const;
		void changeStudyLoad(const char* courseCode);
		void addACourse( char type);
		void loadRecs();
		void saveRecs();
		//Public Member Functions
	public:
		int run();
		//Constructors
		ScmApp();
		~ScmApp();
		friend class ScmAppTester;
		//ms4 Constructors
		ScmApp(const char* filename);
	};
}
#endif
